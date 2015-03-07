using System;
class Mario
{
    public Particle marioCenter;
    public Particle[] marioBody;

    public const int marioParticlesCount = 27;
    public ConsoleKey lastJumpKey;
    public int jumpHeight, steps;
    public bool isJumping;

    public Mario(int row, int col)
    {
        jumpHeight = 10;
        steps = 0;
        isJumping = false;
        lastJumpKey = Engine.ki.Key;

        marioCenter = new Particle(row, col, '█');

        marioBody = new Particle[30];
        // right arm
        marioBody[0] = new Particle(row, col + 1, '█');
        marioBody[1] = new Particle(row, col + 2, '█');
        marioBody[2] = new Particle(row, col + 3, '█');
        marioBody[3] = new Particle(row + 1, col + 3, '█');
        // left arm
        marioBody[4] = new Particle(row, col - 1, '█');
        marioBody[5] = new Particle(row, col - 2, '█');
        marioBody[6] = new Particle(row, col - 3, '█');
        marioBody[7] = new Particle(row + 1, col - 3, '█');

        // torso
        marioBody[8] = new Particle(row + 1, col, '█');
        marioBody[9] = new Particle(row + 1, col - 1, '█');
        marioBody[10] = new Particle(row + 1, col + 1, '█');

        // lower body

        marioBody[11] = new Particle(row + 2, col, '█');
        marioBody[12] = new Particle(row + 3, col + 1, '\x005C');
        marioBody[13] = new Particle(row + 3, col - 1, '/');

        // head

        marioBody[14] = new Particle(row - 1, col, '"');
        marioBody[15] = new Particle(row - 1, col - 2, '\x005C');
        marioBody[16] = new Particle(row - 1, col + 2, '/');
        marioBody[17] = new Particle(row + 3, col - 1, '/');
        marioBody[18] = new Particle(row + 3, col - 1, '/');
        marioBody[19] = new Particle(row - 2, col + 1, 'o');
        marioBody[20] = new Particle(row - 2, col - 1, 'o');
        marioBody[21] = new Particle(row - 2, col - 2, '/');
        marioBody[22] = new Particle(row - 2, col + 2, '\x005C');
        marioBody[23] = new Particle(row - 3, col - 1, '@');
        marioBody[24] = new Particle(row - 3, col, '@');
        marioBody[25] = new Particle(row - 3, col + 1, '@');
        marioBody[26] = new Particle(row - 4, col, '@');
    }

    public void Print()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        marioCenter.Print();
        for (int i = 0; i < marioParticlesCount; i++)
        {
            marioBody[i].Print();
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public void Clear()
    {
        marioCenter.Remove();
        for (int i = 0; i < marioParticlesCount; i++)
        {
            marioBody[i].Remove();
        }
    }

    public bool Collision(string direction, Level level)
    {
        switch (direction)
        {
            case "up":
                {
                    if (level[marioCenter.row - 4] > 0)
                        return level[marioCenter.row - 4, marioCenter.col] == '█' ||
                               level[marioCenter.row - 4, marioCenter.col - 1] == '█' ||
                               level[marioCenter.row - 4, marioCenter.col + 1] == '█' ||
                               level[marioCenter.row - 1, marioCenter.col + 3] == '█' ||
                               level[marioCenter.row - 1, marioCenter.col - 3] == '█' ||
                               level[marioCenter.row - 3, marioCenter.col + 2] == '█' ||
                               level[marioCenter.row - 3, marioCenter.col - 2] == '█';
                } break;
            case "down":
                {
                    if (level[marioCenter.row + 2, marioCenter.col - 3] == '█')
                    {
                        MoveRight(level);
                    }
                    else if (level[marioCenter.row + 2, marioCenter.col + 3] == '█')
                    {
                        MoveLeft(level);
                    }

                    if (level[marioCenter.row + 4] > 0)
                        return level[marioCenter.row + 4, marioCenter.col] == '█' ||
                            level[marioCenter.row + 4, marioCenter.col + 1] == '█' ||
                            level[marioCenter.row + 4, marioCenter.col - 1] == '█';
                } break;
            case "left":
                {

                    return level[marioCenter.row, marioCenter.col - 4] == '█' ||
                        level[marioCenter.row + 1, marioCenter.col - 4] == '█' ||
                        level[marioCenter.row - 1, marioCenter.col - 2] == '█' ||
                        level[marioCenter.row + 3, marioCenter.col - 2] == '█' ||
                        level[marioCenter.row - 4, marioCenter.col - 1] == '█' ||
                        level[marioCenter.row - 3, marioCenter.col - 2] == '█' ||
                        level[marioCenter.row - 2, marioCenter.col - 3] == '█' ||
                        level[marioCenter.row - 1, marioCenter.col - 3] == '█' ||
                        marioCenter.col - 4 < 1;
                }
            case "right":
                {
                    if (level[marioCenter.row] > 0)
                        return level[marioCenter.row, marioCenter.col + 4] == '█' ||
                            level[marioCenter.row + 1, marioCenter.col + 4] == '█' ||
                            level[marioCenter.row - 1, marioCenter.col + 2] == '█' ||
                            level[marioCenter.row + 3, marioCenter.col + 2] == '█' ||
                            level[marioCenter.row - 4, marioCenter.col + 1] == '█' ||
                            level[marioCenter.row - 3, marioCenter.col + 2] == '█' ||
                            level[marioCenter.row - 2, marioCenter.col + 3] == '█' ||
                            level[marioCenter.row - 1, marioCenter.col + 3] == '█';
                } break;
            default: return false;
        }
        return false;
    }

    public void MoveUp(Level level)
    {
        if (marioCenter.row - 4 > 0 && !Collision("up", level))
        {
            marioCenter.MoveParticleUp();
            for (int i = 0; i < marioParticlesCount; i++)
            {
                marioBody[i].MoveParticleUp();
            }
        }
    }

    public void MoveDown(Level level)
    {
        if (marioCenter.row + 4 < Level.levelHeight - 1 && !Collision("down", level))
        {
            marioCenter.MoveParticleDown();
            for (int i = 0; i < marioParticlesCount; i++)
            {
                marioBody[i].MoveParticleDown();
            }
        }
        //else
        //{
        //    if (level[marioCenter.row + 4] == '█')
        //    {
        //        Console.SetCursorPosition(55, 14);
        //        Console.WriteLine("GAME OVER");
        //    }
        //}
    }

    public void MoveLeft(Level level)
    {
        if (marioCenter.col - 3 > 0 && !Collision("left", level))
        {
            marioCenter.MoveParticleLeft();
            for (int i = 0; i < marioParticlesCount; i++)
            {
                marioBody[i].MoveParticleLeft();
            }
        }

    }

    public void MoveRight(Level level)
    {
        if (marioCenter.col + 4 < Console.BufferWidth - 3 && !Collision("right", level))
        {
            marioCenter.MoveParticleRight();
            for (int i = 0; i < marioParticlesCount; i++)
            {
                marioBody[i].MoveParticleRight();
            }
        }
        else
        {
            if (marioCenter.col + 4 >= Console.BufferWidth - 10 && Level.levelCounter < 5)
            {
                // start a new level
                Level.levelCounter++;

                SetToBeggining();

                Engine.level = new Level();
                level = new Level();
                level.Print();
                Print();

            }
            //if (!Collision("right", level))
            //{
            //    marioCenter.MoveParticleRight();
            //    for (int i = 0; i < marioParticlesCount; i++)
            //    {
            //        marioBody[i].MoveParticleRight();
            //    }
            //}
        }
    }

    public void Jump(Level level, ConsoleKey key)
    {
        // go up for a set height
        if (steps++ < jumpHeight)
        {
            MoveUp(level);

            // look for a key change
            if (key == ConsoleKey.LeftArrow)
            {
                MoveLeft(level);
                lastJumpKey = key;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                MoveRight(level);
                lastJumpKey = key;
            }

        }
        else // if you have already reached the height, start going down
        {
            MoveDown(level);

            // look for a key change
            if (key == ConsoleKey.LeftArrow)
            {
                MoveLeft(level);
                lastJumpKey = key;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                MoveRight(level);
                lastJumpKey = key;
            }

            // finish the jump
            if (steps == jumpHeight * 2)
            {
                isJumping = false;
                steps = 0;
            }

            lastJumpKey = Engine.ki.Key;

        }
    }

    public bool isDead(Enemy en, Level level)
    {

        for (int i = 0; i < marioParticlesCount; i++)
        {

            if ((marioCenter.col >= en.PosX - 1 && marioCenter.col <= en.PosX + en.EnemyWidth)
                && marioBody[i].row >= en.PosY + 1 &&marioBody[i].row <= en.PosY +3)
            {
                return true;
            }
        }
        return false;
    }

    public bool MarioInTheHole()
    {
        return marioCenter.row + 4 > 25;
    }

    public void SetToBeggining()
    {
        marioCenter.col -= Console.BufferWidth - 15;
        for (int i = 0; i < marioParticlesCount; i++)
        {
            marioBody[i].col -= Console.BufferWidth - 15;
        }
    }
}


