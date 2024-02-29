
namespace Lab4CSharp
{
    public class VectorUshort
    {
        private ushort[] ArrayUShort;
        private uint num;
        private uint codeError;
        private static uint num_vs;

        public VectorUshort()
        {
            this.num = 1;
            this.ArrayUShort = new ushort[num];
            ArrayUShort[0] = 0;
            num_vs++;
        }
        public VectorUshort(uint num)
        {
            this.num = num;
            ArrayUShort = new ushort[num];
            for (uint i = 0; i < num; i++)
            {
                ArrayUShort[i] = 0;
            }
            num_vs++;
        }
        public VectorUshort(uint num, ushort value)
        {
            this.num = num;
            ArrayUShort = new ushort[num];
            for (uint i = 0; i < num; i++)
            {
                ArrayUShort[i] = value;
            }
            num_vs++;
        }
        // Деструктор
        ~VectorUshort()
        {
            Console.WriteLine("VectorUshort object is being destroyed.");
        }
        public void Fill()
        {
            for (uint i = 0; i < num; i++)
            {
                this.ArrayUShort[i] = ushort.Parse(Console.ReadLine());
            }
        }
        public void Print()
        {
            for (uint i = 0; i < num; i++)
            {
                Console.Write(this.ArrayUShort[i] + " ");
            }
            Console.WriteLine();
        }
        static void Count()
        {
            Console.WriteLine(num_vs);
        }
        public void Enter(ushort value)
        {
            for (uint i = 0; i < num; i++)
            {
                this.ArrayUShort[i] = value;
            }
        }
        public uint Num
        {
            get { return num; }
        }
        public uint CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }
        public ushort this[int index]
        {
            get
            {
                if (index < 0 || index >= num)
                {
                    codeError = 1;
                    return 0;
                }
                // Повертаємо значення індексу масиву
                return ArrayUShort[index];
            }
            set
            {
                if (index < 0 || index >= num)
                {
                    codeError = 1;
                    return;
                }
                // Записуємо значення індексу масиву
                ArrayUShort[index] = value;
            }
        }
        public static VectorUshort operator ++(VectorUshort vector)
        {
            for (uint i = 0; i < vector.ArrayUShort.Length; i++)
            {
                vector.ArrayUShort[i]++;
            }
            return vector;
        }

        public static VectorUshort operator --(VectorUshort vector)
        {
            for (uint i = 0; i < vector.ArrayUShort.Length; i++)
            {
                vector.ArrayUShort[i]--;
            }
            return vector;
        }
        public static bool operator true(VectorUshort vector)
        {
            return vector.num != 0 && !vector.ArrayUShort.Any(element => element == 0);
        }

        public static bool operator false(VectorUshort vector)
        {
            return vector.num == 0 || vector.ArrayUShort.Any(element => element != 0);
        }
        public static bool operator !(VectorUshort vector)
        {
            return vector.num != 0;
        }
        public override string ToString()
        {
            return $"{this.num}";
        }
        public static VectorUshort operator ~(VectorUshort vector)
        {
            VectorUshort result = new VectorUshort(vector.num);
            for (uint i = 0; i < vector.num; i++)
            {
                result.ArrayUShort[i] = (ushort)~vector.ArrayUShort[i];
            }
            return result;
        }
        public static VectorUshort operator +(VectorUshort vector1, VectorUshort vector2)
        {
            if (vector1 == null || vector2 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (vector1.num != vector2.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            VectorUshort result = new VectorUshort(vector1.num);

            // Додавання відповідних елементів
            for (uint i = 0; i < vector1.num; i++)
            {
                // Перевірка на переповнення для кожного елемента
                if (vector1.ArrayUShort[i] > ushort.MaxValue - vector2.ArrayUShort[i])
                {
                    throw new OverflowException("При додаванні елементів виникло переповнення.");
                }

                result.ArrayUShort[i] = (ushort)(vector1.ArrayUShort[i] + vector2.ArrayUShort[i]);
            }

            return result;

        }

        // Перевантаження бінарної операції додавання для вектора і скаляра ushort
        public static VectorUshort operator +(VectorUshort vector1, ushort scalar)
        {
            VectorUshort vector = new VectorUshort(vector1.num);
            if (vector1 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            for (uint i = 0; i < vector.num; i++)
            {
                vector.ArrayUShort[i] = (ushort)(vector1.ArrayUShort[i] + scalar);
            }

            return vector;
        }

        // Перевантаження бінарної операції віднімання для двох векторів
        public static VectorUshort operator -(VectorUshort vector1, VectorUshort vector2)
        {
            if (vector1 == null || vector2 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (vector1.num != vector2.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            VectorUshort result = new VectorUshort(vector1.num);

            // Додавання відповідних елементів
            for (uint i = 0; i < vector1.num; i++)
            {
                if (vector1.ArrayUShort[i] < vector2.ArrayUShort[i])
                {
                    //throw new InvalidOperationException("Віднімання може призвести до від'ємного результату.");
                    Console.WriteLine("Відємне значення виходить");
                    result.ArrayUShort[i] = 0;
                    continue;
                }

                result.ArrayUShort[i] = (ushort)(vector1.ArrayUShort[i] - vector2.ArrayUShort[i]);
            }

            return result;
        }

        // Перевантаження бінарної операції віднімання для вектора і скаляра ushort
        public static VectorUshort operator -(VectorUshort vector1, ushort scalar)
        {
            VectorUshort vector = new VectorUshort(vector1.num);
            if (vector1 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            for (uint i = 0; i < vector1.num; i++)
            {
                if (vector1.ArrayUShort[i] < scalar)
                {
                    //throw new InvalidOperationException("Віднімання може призвести до від'ємного результату.");
                    Console.WriteLine("Відємне значення виходить");
                    vector.ArrayUShort[i] = 0;
                    continue;
                }

                vector.ArrayUShort[i] = (ushort)(vector1.ArrayUShort[i] - scalar);
            }

            return vector;
        }

        // Перевантаження бінарної операції множення для двох векторів
        public static VectorUshort operator *(VectorUshort left, VectorUshort right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (left.num != right.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorUshort result = new VectorUshort(left.num);

            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayUShort[i] > ushort.MaxValue / right.ArrayUShort[i])
                {
                    throw new OverflowException("При множенні елементів виникло переповнення.");
                }
                result.ArrayUShort[i] = (ushort)(left.ArrayUShort[i] * right.ArrayUShort[i]);
            }

            return result;
        }

        // Перевантаження бінарної операції множення для вектора і скаляра ushort
        public static VectorUshort operator *(VectorUshort vector1, ushort scalar)
        {
            VectorUshort vector = new VectorUshort(vector1.num);
            if (vector1 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            for (uint i = 0; i < vector1.num; i++)
            {
                vector.ArrayUShort[i] = (ushort)(vector1.ArrayUShort[i] * scalar);
            }

            return vector;
        }

        // Перевантаження бінарної операції ділення для двох векторів
        public static VectorUshort operator /(VectorUshort vector1, VectorUshort vector2)
        {
            if (vector1 == null || vector2 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (vector1.num != vector2.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            VectorUshort result = new VectorUshort(vector1.num);

            // Додавання відповідних елементів
            for (uint i = 0; i < vector1.num; i++)
            {
                if (vector2.ArrayUShort[i] == 0)
                {
                    throw new InvalidOperationException("Є нульові елементи");
                }

                result.ArrayUShort[i] = (ushort)(vector1.ArrayUShort[i] / vector2.ArrayUShort[i]);
            }

            return result;
        }

        // Перевантаження бінарної операції ділення для вектора і скаляра ushort
        public static VectorUshort operator /(VectorUshort vector1, ushort scalar)
        {
            VectorUshort vector = new VectorUshort(vector1.num);
            if (vector1 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            for (uint i = 0; i < vector1.num; i++)
            {
                if (scalar == 0)
                {
                    throw new InvalidOperationException("Не допустиме ділення на нуль");
                }

                vector.ArrayUShort[i] = (ushort)(vector1.ArrayUShort[i] / scalar);
            }

            return vector;
        }

        // Перевантаження бінарної операції остачі від ділення для двох векторів
        public static VectorUshort operator %(VectorUshort vector1, VectorUshort vector2)
        {
            if (vector1 == null || vector2 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (vector1.num != vector2.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            VectorUshort result = new VectorUshort(vector1.num);

            // Додавання відповідних елементів
            for (uint i = 0; i < vector1.num; i++)
            {
                if (vector2.ArrayUShort[i] == 0)
                {
                    throw new InvalidOperationException("Є нульові елементи");
                }

                result.ArrayUShort[i] = (ushort)(vector1.ArrayUShort[i] % vector2.ArrayUShort[i]);
            }

            return result;
        }

        // Перевантаження бінарної операції остачі від ділення для вектора і скаляра ushort
        public static VectorUshort operator %(VectorUshort vector1, ushort scalar)
        {
            VectorUshort vector = new VectorUshort(vector1.num);
            if (vector1 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            for (uint i = 0; i < vector1.num; i++)
            {
                if (scalar == 0)
                {
                    throw new InvalidOperationException("Не допустиме ділення на нуль");
                }

                vector.ArrayUShort[i] = (ushort)(vector1.ArrayUShort[i] % scalar);
            }

            return vector;
        }
        public static VectorUshort operator |(VectorUshort left, VectorUshort right)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorUshort result = new VectorUshort(left.num);

            for (uint i = 0; i < left.num; i++)
            {
                result.ArrayUShort[i] = (ushort)(left.ArrayUShort[i] | right.ArrayUShort[i]);
            }

            return result;
        }
        public static VectorUshort operator |(VectorUshort vector, ushort scalar)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorUshort result = new VectorUshort(vector.num);

            for (uint i = 0; i < vector.num; i++)
            {
                result.ArrayUShort[i] = (ushort)(vector.ArrayUShort[i] | scalar);
            }

            return result;
        }
        public static VectorUshort operator ^(VectorUshort left, VectorUshort right)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorUshort result = new VectorUshort(left.num);

            for (uint i = 0; i < left.num; i++)
            {
                result.ArrayUShort[i] = (ushort)(left.ArrayUShort[i] ^ right.ArrayUShort[i]);
            }

            return result;
        }
        public static VectorUshort operator ^(VectorUshort vector, ushort scalar)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorUshort result = new VectorUshort(vector.num);

            for (uint i = 0; i < vector.num; i++)
            {
                result.ArrayUShort[i] = (ushort)(vector.ArrayUShort[i] ^ scalar);
            }

            return result;
        }
        public static VectorUshort operator &(VectorUshort left, VectorUshort right)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorUshort result = new VectorUshort(left.num);

            for (uint i = 0; i < left.num; i++)
            {
                result.ArrayUShort[i] = (ushort)(left.ArrayUShort[i] & right.ArrayUShort[i]);
            }

            return result;
        }
        public static VectorUshort operator &(VectorUshort vector, ushort scalar)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorUshort result = new VectorUshort(vector.num);

            for (uint i = 0; i < vector.num; i++)
            {
                result.ArrayUShort[i] = (ushort)(vector.ArrayUShort[i] & scalar);
            }

            return result;
        }
        public static VectorUshort operator >>(VectorUshort vector, int shift)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorUshort result = new VectorUshort(vector.num);

            for (uint i = 0; i < vector.num; i++)
            {
                result.ArrayUShort[i] = (ushort)(vector.ArrayUShort[i] >> shift);
            }

            return result;
        }
        public static VectorUshort operator <<(VectorUshort left, int shift)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorUshort result = new VectorUshort(left.num);

            for (uint i = 0; i < left.num; i++)
            {
                result.ArrayUShort[i] = (ushort)(left.ArrayUShort[i] << shift);
            }

            return result;
        }
        public static bool operator ==(VectorUshort left, VectorUshort right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            if (left.num != right.num)
                return false;

            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayUShort[i] != right.ArrayUShort[i])
                    return false;
            }

            return true;
        }
        public static bool operator !=(VectorUshort left, VectorUshort right)
        {
            return !(left == right);
        }
        public static bool operator >(VectorUshort left, VectorUshort right)
        {
            if (left.num != right.num)
                throw new ArgumentException("Vectors must have the same length for comparison.");

            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayUShort[i] <= right.ArrayUShort[i])
                    return false;
            }

            return true;
        }
        public static bool operator <(VectorUshort left, VectorUshort right)
        {
            if (left.num != right.num)
                throw new ArgumentException("Vectors must have the same length for comparison.");

            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayUShort[i] >= right.ArrayUShort[i])
                    return false;
            }

            return true;
        }
        public static bool operator >=(VectorUshort left, VectorUshort right)
        {
            if (left.num != right.num)
                throw new ArgumentException("Vectors must have the same length for comparison.");

            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayUShort[i] < right.ArrayUShort[i])
                    return false;
            }

            return true;
        }
        public static bool operator <=(VectorUshort left, VectorUshort right)
        {
            if (left.num != right.num)
                throw new ArgumentException("Vectors must have the same length for comparison.");

            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayUShort[i] > right.ArrayUShort[i])
                    return false;
            }

            return true;
        }
    }
}