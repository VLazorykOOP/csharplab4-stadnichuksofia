using Lab4CSharp;

Console.WriteLine("Lab 4 CSharp");
while (true)
{
    Console.WriteLine("Enter the task number:");
    string input = Console.ReadLine();
    int n;
    if (int.TryParse(input, out n))
    {
        switch (n)
    {
        case 1:
            Romb romb = new Romb(7, 4 * Math.Sqrt(2), "Red");

            Console.WriteLine(romb[0]);
            Console.WriteLine(romb[1]);
            Console.WriteLine(romb[2]);

            // Overloading true and false
            Console.WriteLine(romb ? "Is Square" : "Is not Square");

            ++romb;
            Console.WriteLine($"After ++: {romb}");

            //--romb;
            Console.WriteLine($"After --: {romb}");

            // Overloading the * operator
            romb = romb * 2;
            Console.WriteLine($"After * 2: {romb}");

            // Type conversion from Romb to string and vice versa
            string rombString = romb;
            Console.WriteLine($"Romb as string: {rombString}");

            Romb newRomb = rombString;
            Console.WriteLine($"String as Romb: {newRomb}");
            Console.ReadLine();

            break;
        case 2:
            VectorUshort vector1 = new VectorUshort(5);
            VectorUshort vector2 = new VectorUshort(5);

            Console.WriteLine("Demonstration of manual input");
            vector2.Fill();
            vector2.Print();

            Console.WriteLine("Demonstration of Filling with scalar(2)");
            vector2.Enter(2);
            vector2.Print();

            Console.WriteLine(vector2.Num);

            vector2.CodeError = 0;
            Console.WriteLine(vector2.CodeError);

            Console.WriteLine("Correct " + vector2[1] + " Incorrect " + vector2[10]);

            Console.WriteLine(vector2.CodeError);

            Console.WriteLine("Demonstration ++");
            vector2++;
            vector2.Print();

            Console.WriteLine("Demonstration --");
            vector2--;
            vector2--;
            vector2.Print();

            vector2.Fill();
            Console.WriteLine("Demonstration True/False");
            if (vector2) Console.WriteLine("Not equal to zero");
            else Console.WriteLine("Vector dimension or one of the elements equals 0 ");

            VectorUshort vectorNot = new VectorUshort(2);
            VectorUshort vector = new VectorUshort(vector1.Num);
            ushort scalar = 2;
            Console.WriteLine("Overloading +");
            vector = vector1 + vector2;
            vector.Print();
            //vector = vector1 + vectorNot;
            //vector.Print();
            vector = vector2 + scalar;
            vector.Print();

            Console.WriteLine("Overloading -");
            vector = vector2 - vector1;
            vector.Print();
            //vector = vector1 - vectorNot;
            //vector.Print();
            vector = vector2 - scalar;
            vector.Print();

            Console.WriteLine("Overloading *");
            vector = vector1 * vector2;
            vector.Print();
            vector = vector2 * scalar;
            vector.Print();

            Console.WriteLine("Overloading /");
            vector = vector2 / vector1;
            vector.Print();
            vector = vector2 / scalar;
            vector.Print();

            Console.WriteLine("Overloading %");
            vector = vector2 % vector1;
            vector.Print();
            vector = vector2 % scalar;
            vector.Print();

            Console.WriteLine("Overloading |");
            vector = vector2 | vector1;
            vector.Print();
            vector = vector2 | scalar;
            vector.Print();

            Console.WriteLine("Overloading >>");
            vector = vector2 >> scalar;
            vector.Print();

            Console.WriteLine("Overloading <<");
            vector = vector2 << scalar;
            vector.Print();

            Console.WriteLine("Overloading ==");
            Console.WriteLine(vector1 == vector);
            vector1 = vector2;
            Console.WriteLine(vector1 == vector2);

            Console.WriteLine("Overloading !=");
            Console.WriteLine(vector1 != vector);

            Console.WriteLine("Overloading >");
            Console.WriteLine(vector1 > vector);

            Console.WriteLine("Overloading <");
            Console.WriteLine(vector1 < vector);

            Console.WriteLine("Overloading >=");
            Console.WriteLine(vector1 >= vector);

            Console.WriteLine("Overloading <=");
            Console.WriteLine(vector1 <= vector);
            break;
        case 3:
            MatrixUshort matrix1 = new MatrixUshort(2, 2);
            MatrixUshort matrix2 = new MatrixUshort(2, 2);

            matrix1.Print();

            Console.WriteLine("Manual input demonstration");
            matrix1.Fill();
            matrix1.Print();

            Console.WriteLine("Filling with scalar(3)");
            matrix2.Enter(3);
            matrix2.Print();

            matrix2.CodeError = 0;
            Console.WriteLine(matrix2.CodeError);

            Console.WriteLine("Correct " + matrix1[0, 1] + " Incorrect " + matrix2[4, 5]);
            Console.WriteLine("Through the k index - " + matrix1[3]);
            Console.WriteLine(matrix2.CodeError);

            Console.WriteLine("Demonstration ++");
            matrix1++;
            matrix1.Print();

            Console.WriteLine("Demonstration --");
            matrix2--;
            matrix2--;
            matrix2.Print();

            matrix2.Fill();
            Console.WriteLine("Demonstration True/False");
            if (matrix2) Console.WriteLine("Not equal to zero");
            else Console.WriteLine("Matrix dimension or one of the elements equals 0 ");

            MatrixUshort matrix = new MatrixUshort(2, 2);
            ushort scalar1 = 2;
            Console.WriteLine("Overloading +");
            matrix = matrix1 + matrix2;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix1 + scalar1;
            matrix.Print();

            Console.WriteLine("Overloading -");
            matrix = matrix2 - matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 - scalar1;
            matrix.Print();

            Console.WriteLine("Overloading *");
            matrix = matrix1 * matrix2;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 * scalar1;
            matrix.Print();

            Console.WriteLine("Overloading /");
            matrix = matrix2 / matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 / scalar1;
            matrix.Print();

            Console.WriteLine("Overloading %");
            matrix = matrix2 % matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 % scalar1;
            matrix.Print();

            Console.WriteLine("Overloading |");
            matrix = matrix2 | matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 | scalar1;
            matrix.Print();

            Console.WriteLine("Overloading >>");
            matrix = matrix2 >> scalar1;
            matrix.Print();

            Console.WriteLine("Overloading <<");
            matrix = matrix2 << scalar1;
            matrix.Print();

            Console.WriteLine("Overloading ==");
            Console.WriteLine(matrix1 == matrix);
            matrix1 = matrix2;
            Console.WriteLine(matrix1 == matrix2);

            Console.WriteLine("Overloading !=");
            Console.WriteLine(matrix1 != matrix);

            Console.WriteLine("Overloading >");
            Console.WriteLine(matrix1 > matrix);

            Console.WriteLine("Overloading <");
            Console.WriteLine(matrix1 < matrix);

            Console.WriteLine("Overloading >=");
            Console.WriteLine(matrix1 >= matrix);

            Console.WriteLine("Overloading <=");
            Console.WriteLine(matrix1 <= matrix);

            break;
        default:
            Console.WriteLine("Incorrect");
            break;
         }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid integer.");
        break; // Exit the loop if input is invalid
    }
}