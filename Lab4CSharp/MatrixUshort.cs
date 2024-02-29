using Lab4CSharp;
using System;
using System.Numerics;

public class MatrixUshort
{
    private ushort[,] ShortIntArray;
    int n, m;
    int codeError;
    static int num_m;
    public MatrixUshort()
    {
        this.n = 1;
        this.m = 0;
        this.codeError = 0;
        this.ShortIntArray = new ushort[n, m];
        ShortIntArray[n, m] = 0;
        num_m++;
    }
    public MatrixUshort(int rows, int columns)
    {
        this.n = rows;
        this.m = columns;
        this.codeError = 0;
        this.ShortIntArray = new ushort[n, m];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                ShortIntArray[i, j] = 0;
            }
        }
        num_m++;
    }
    public MatrixUshort(int rows, int columns, ushort value)
    {
        this.n = rows;
        this.m = columns;
        this.codeError = 0;
        this.ShortIntArray = new ushort[n, m];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                ShortIntArray[i, j] = value;
            }
        }
        num_m++;
    }
    ~MatrixUshort()
    {
        Console.WriteLine("MatrixUshort object is being destroyed.");
    }
    public void Fill()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ushort value;
                if (!ushort.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Invalid input. Please enter a valid ushort value.");
                }
                value = 0;
            }
            ShortIntArray[i, j] = value;
        }
    }
}
public void Print()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(this.ShortIntArray[i, j] + " ");
            }
            Console.WriteLine();
        };
    }
    static void Count()
    {
        Console.WriteLine(num_m);
    }
    public void Enter(ushort value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortIntArray[i, j] = value;
            }
        }
    }
    public int N
    {
        get { return N; }
    }
    public int M
    {
        get { return M; }
    }
    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }
    public int this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = 1;
                return 0;
            }

            codeError = 0;
            return ShortIntArray[i, j];
        }
        set
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = 1;
                return;
            }

            ShortIntArray[i, j] = (ushort)value;
            codeError = 0;
        }
    }

    // Індексатор з одним індексом
    public int this[int k]
    {
        get
        {
            int i = k / m;
            int j = k % m;

            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = 1;
                return 0;
            }

            codeError = 0;
            return ShortIntArray[i, j];
        }
        set
        {
            int i = k / m;
            int j = k % m;

            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
                return;
            }

            ShortIntArray[i, j] = (ushort)value;
            codeError = 0;
        }
    }
    public static MatrixUshort operator ++(MatrixUshort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortIntArray[i, j]++;
            }
        };
        return matrix;
    }

    public static MatrixUshort operator --(MatrixUshort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortIntArray[i, j]--;
            }
        };
        return matrix;
    }
    static public bool HasZeroElement(MatrixUshort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                if (matrix.ShortIntArray[i, j] == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public static bool operator true(MatrixUshort matrix)
    {
        bool hasZero = HasZeroElement(matrix);
        return matrix.n != 0 && matrix.m != 0 && !hasZero;
    }

    public static bool operator false(MatrixUshort matrix)
    {
        bool hasZero = HasZeroElement(matrix);
        return matrix.n == 0 || matrix.m == 0 || hasZero;
    }
    public static bool operator !(MatrixUshort matrix)
    {
        return matrix.n != 0 && matrix.m != 0;
    }
    public override string ToString()
    {
        return $"{this.n}";
    }
    public static MatrixUshort operator ~(MatrixUshort matrix)
    {
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)~matrix.ShortIntArray[i, j]++;
            }
        };
        return result;
    }
    public static MatrixUshort operator +(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            throw new ArgumentNullException("The input matrices cannot be zero.");
        }
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("The dimensions of the matrices must be the same.");
        }
        MatrixUshort result = new MatrixUshort(matrix1.n, matrix1.m);

        // Додавання відповідних елементів
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                // Перевірка на переповнення для кожного елемента
                if (matrix1.ShortIntArray[i, j] > ushort.MaxValue - matrix2.ShortIntArray[i, j])
                {
                    throw new OverflowException("An overflow occurred while adding items.");
                }
                result.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] + matrix2.ShortIntArray[i, j]);

            }
        };
        return result;

    }

    // Перевантаження бінарної операції додавання для вектора і скаляра ushort
    public static MatrixUshort operator +(MatrixUshort matrix1, ushort scalar)
    {
        MatrixUshort matrix = new MatrixUshort(matrix1.n, matrix1.m);
        if (matrix1 == null)
        {
            throw new ArgumentNullException("The input vectors cannot be zero.");
        }
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {

                matrix.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] + scalar);

            }
        };

        return matrix;
    }

    // Перевантаження бінарної операції віднімання для двох векторів
    public static MatrixUshort operator -(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            throw new ArgumentNullException("The input vectors cannot be zero.");
        }
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("The dimensions of the matrices must be the same.");
        }
        MatrixUshort result = new MatrixUshort(matrix1.n, matrix1.m);

        // Додавання відповідних елементів
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                // Перевірка на переповнення для кожного елемента
                if (matrix1.ShortIntArray[i, j] < matrix2.ShortIntArray[i, j])
                {
                    //throw new InvalidOperationException("Віднімання може призвести до від'ємного результату.");
                    Console.WriteLine("A negative value is obtained");
                    result.ShortIntArray[i, j] = 0;
                    continue;
                }
                result.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] - matrix2.ShortIntArray[i, j]);

            }
        };
        return result;
    }

    // Перевантаження бінарної операції віднімання для вектора і скаляра ushort
    public static MatrixUshort operator -(MatrixUshort matrix1, ushort scalar)
    {
        MatrixUshort matrix = new MatrixUshort(matrix1.n, matrix1.m);
        if (matrix1 == null)
        {
            throw new ArgumentNullException("The input vectors cannot be zero.");
        }
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix1.ShortIntArray[i, j] < scalar)
                {
                    //throw new InvalidOperationException("Віднімання може призвести до від'ємного результату.");
                    Console.WriteLine("A negative value is obtained");
                    matrix.ShortIntArray[i, j] = 0;
                    continue;
                }
                matrix.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] - scalar);
            }
        };

        return matrix;
    }

    // Перевантаження бінарної операції множення для двох векторів
    public static MatrixUshort operator *(MatrixUshort left, MatrixUshort right)
    {
        if (left == null || right == null)
        {
            throw new ArgumentNullException("The input matrices cannot be zero.");
        }
        if (left.n != right.n)
        {
            throw new ArgumentException("The dimensions of the matrices must be the same.");
        }
        // Перевірка на валідність вхідних параметрів може бути додана за необхідності
        MatrixUshort result = new MatrixUshort(left.n, left.m);

        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] > ushort.MaxValue / right.ShortIntArray[i, j])
                {
                    throw new OverflowException("An overflow occurred while multiplying the elements.");
                }
                result.ShortIntArray[i, j] = (ushort)(left.ShortIntArray[i, j] * right.ShortIntArray[i, j]);
            }
        };


        return result;
    }

    // Перевантаження бінарної операції множення для вектора і скаляра ushort
    public static MatrixUshort operator *(MatrixUshort matrix1, ushort scalar)
    {
        MatrixUshort matrix = new MatrixUshort(matrix1.n, matrix1.m);
        if (matrix1 == null)
        {
            throw new ArgumentNullException("Input vectors cannot be zero.");
        }
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                matrix.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] * scalar);
            }
        };

        return matrix;
    }

    // Перевантаження бінарної операції ділення для двох векторів
    public static MatrixUshort operator /(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            throw new ArgumentNullException("Input vectors cannot be zero.");
        }
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("The dimensions of the matrices must be the same.");
        }
        MatrixUshort result = new MatrixUshort(matrix1.n, matrix1.m);

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix2.ShortIntArray[i, j] == 0)
                {
                    throw new InvalidOperationException("There are null elements");
                }

                result.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] / matrix2.ShortIntArray[i, j]);
            }
        };
        return result;
    }

    // Перевантаження бінарної операції ділення для вектора і скаляра ushort
    public static MatrixUshort operator /(MatrixUshort matrix1, ushort scalar)
    {
        MatrixUshort matrix = new MatrixUshort(matrix1.n, matrix1.m);
        if (matrix1 == null)
        {
            throw new ArgumentNullException("The input matrices cannot be zero.");
        }
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (scalar == 0)
                {
                    throw new InvalidOperationException("Division by 0 is not allowed");
                }

                matrix.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] / scalar);
            }
        };

        return matrix;
    }

    // Перевантаження бінарної операції остачі від ділення для двох векторів
    public static MatrixUshort operator %(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            throw new ArgumentNullException("The input vectors cannot be zero.");
        }
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("The dimensions of the matrices must be the same.");
        }
        MatrixUshort result = new MatrixUshort(matrix1.n, matrix1.m);

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix2.ShortIntArray[i, j] == 0)
                {
                    throw new InvalidOperationException("There are null elements");
                }

                result.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] % matrix2.ShortIntArray[i, j]);
            }
        };
        return result;
    }

    // Перевантаження бінарної операції остачі від ділення для вектора і скаляра ushort
    public static MatrixUshort operator %(MatrixUshort matrix1, ushort scalar)
    {
        MatrixUshort matrix = new MatrixUshort(matrix1.n, matrix1.m);
        if (matrix1 == null)
        {
            throw new ArgumentNullException("The input matrices cannot be zero.");
        }
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                matrix.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] % scalar);
            }
        };

        return matrix;
    }
    public static MatrixUshort operator |(MatrixUshort left, MatrixUshort right)
    {
        // Перевірка на валідність вхідних параметрів може бути додана за необхідності
        MatrixUshort result = new MatrixUshort(left.n, right.m);
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(left.ShortIntArray[i, j] | right.ShortIntArray[i, j]);
            }
        };
        return result;
    }
    public static MatrixUshort operator |(MatrixUshort matrix, ushort scalar)
    {
        // Перевірка на валідність вхідних параметрів може бути додана за необхідності
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(matrix.ShortIntArray[i, j] | scalar);
            }
        };

        return result;
    }
    public static MatrixUshort operator ^(MatrixUshort left, MatrixUshort right)
    {
        // Перевірка на валідність вхідних параметрів може бути додана за необхідності
        MatrixUshort result = new MatrixUshort(left.n, left.m);

        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(left.ShortIntArray[i, j] ^ right.ShortIntArray[i, j]);
            }
        };

        return result;
    }
    public static MatrixUshort operator ^(MatrixUshort matrix, ushort scalar)
    {
        // Перевірка на валідність вхідних параметрів може бути додана за необхідності
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(matrix.ShortIntArray[i, j] ^ scalar);
            }
        };

        return result;
    }
    public static MatrixUshort operator &(MatrixUshort left, MatrixUshort right)
    {
        // Перевірка на валідність вхідних параметрів може бути додана за необхідності
        // Перевірка на валідність вхідних параметрів може бути додана за необхідності
        MatrixUshort result = new MatrixUshort(left.n, left.m);

        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(left.ShortIntArray[i, j] & right.ShortIntArray[i, j]);
            }
        };

        return result;
    }
    public static MatrixUshort operator &(MatrixUshort matrix, ushort scalar)
    {
        // Перевірка на валідність вхідних параметрів може бути додана за необхідності
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(matrix.ShortIntArray[i, j] & scalar);
            }
        };

        return result;
    }
    public static MatrixUshort operator >>(MatrixUshort matrix, int shift)
    {
        // Перевірка на валідність вхідних параметрів може бути додана за необхідності
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(matrix.ShortIntArray[i, j] >> shift);
            }
        };


        return result;
    }
    public static MatrixUshort operator <<(MatrixUshort matrix, int shift)
    {
        // Перевірка на валідність вхідних параметрів може бути додана за необхідності
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(matrix.ShortIntArray[i, j] << shift);
            }
        };
        return result;
    }
    public static bool operator ==(MatrixUshort left, MatrixUshort right)
    {
        if (ReferenceEquals(left, right))
            return true;

        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            return false;

        if (left.n != right.n || left.m != right.m)
            return false;
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] != right.ShortIntArray[i, j])
                    return false;
            }
        };
        return true;
    }
    public static bool operator !=(MatrixUshort left, MatrixUshort right)
    {
        return !(left == right);
    }
    public static bool operator >(MatrixUshort left, MatrixUshort right)
    {
        if (left.n != right.n || left.m != right.m)
            throw new ArgumentException("matrixs must have the same length for comparison.");
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] <= right.ShortIntArray[i, j])
                    return false;
            }
        };
        return true;
    }
    public static bool operator <(MatrixUshort left, MatrixUshort right)
    {
        if (left.n != right.n || left.m != right.m)
            throw new ArgumentException("matrixs must have the same length for comparison.");
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] >= right.ShortIntArray[i, j])
                    return false;
            }
        };
        return true;
    }
    public static bool operator >=(MatrixUshort left, MatrixUshort right)
    {
        if (left.n != right.n || left.m != right.m)
            throw new ArgumentException("matrixs must have the same length for comparison.");
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] < right.ShortIntArray[i, j])
                    return false;
            }
        };
        return true;
    }
    public static bool operator <=(MatrixUshort left, MatrixUshort right)
    {
        if (left.n != right.n || left.m != right.m)
            throw new ArgumentException("matrixs must have the same length for comparison.");
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] > right.ShortIntArray[i, j])
                    return false;
            }
        };
        return true;
    }
}
