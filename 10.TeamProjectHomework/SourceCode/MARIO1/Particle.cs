using System;

/// <summary>
/// Represents the elements from which the Mario czzzzzzzzzzzzzzzzzzzzzzzzzzz
/// </summary>
class Particle
{
    public int row, col;
    public char symbol;

    public Particle(int row, int col, char symbol)
    {
        this.row = row;
        this.col = col;
        this.symbol = symbol;
    }

    //public void SetParticle(int row = 0, int col = 0, char symbol = ' ')
    //{
    //    this.row = row;
    //    this.col = col;
    //    this.symbol = symbol;
    //}

    public Particle()
    {
        row = 0;
        col = 0;
        symbol = ' ';
    }

    public void MoveParticleUp()
    {
        if (row - 1 >= 0)
        {
            this.row--;
        }
    }

    public void MoveParticleDown()
    {
        if (row + 1 <= Console.BufferHeight)
        {
            this.row++;
        }
    }

    public void MoveParticleLeft()
    {
        if (col - 1 >= 0)
        {
            this.col--;
        }
    }

    public void MoveParticleRight()
    {

        if (col + 1 <= Console.BufferWidth)
        {
            this.col++;
        }
    }

    public void Print()
    {
        Console.SetCursorPosition(col, row);
        Console.Write(symbol);
    }

    public void Remove()
    {
        Console.SetCursorPosition(col, row);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("█");
    }
}

