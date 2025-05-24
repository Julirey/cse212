public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // <Proccess>
        // Step 1: First we'd need to declare and initiate an array of doubles with a size equal to the "length" parameter.
        //      (This array is where the multiples will be stored.)
        // Step 2: Now make a for-loop that will find the multiples as many times as the number of "length".
        // Step 3: Inside the loop, use the index number of the loop, add 1, and multiply it to the "number" parameter.
        //      (Since arrays start at 0, adding 1 is necessary to get the proper multiple in the sequence.)
        // Step 4: Assign the result to the respective position in the multiples array using the loop index.
        // Step 5: Outside the loop, return the multiples array.

        // Step 1: Create double array equal to length
        double[] multiples = new double[length];

        // Step 2: Add for-loop that iterate through the number of "length"
        for (int i = 0; i < length; i++)
        {
            // Step 3 & 4: Add 1 to the loop index and multiply it to the number,
            //          Assign the result to the multiples array with loop index as the position
            multiples[i] = number * (i + 1);
        }

        // Step 5: Once the loop finishes, return the multiples array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // <Proccess>
        // Step 1: Create a new static array to hold the rotated list, base the size of the array via using the Count function with the "data" list.
        // Step 2: Use a for-loop to iterate each item in the data list.
        // Step 3: Add the index with the "amount" parameter number (number of steps to the right), and get the modulus by the number of items in the list.
        //      (This handles step numbers larger than the list size by wrapping around the index number back to 0, thus getting the new index for the number.)
        // Step 4: Add the item of the respective iteration to the new array assigned to the new index.
        // Step 5: Clear the original list with the Clear() function so that it can be replaced by the new array.
        // Step 6: Add the new array to the original list with AddRange() function.

        // Step 1: Create new static array using the count of the data list as the size
        int[] newArray = new int[data.Count];

        // Step 2: Use a for-loop to iterate through each item in the "data" list
        for (int i = 0; i < data.Count; i++)
        {
            // Step 3: Add the "amount" of steps to the index, and get the modulus by the number of list items to get the new index 
            int newIndex = (i + amount) % data.Count;

            // Step 4: Assign the current item to the new array at its new position
            newArray[newIndex] = data[i];
        }
        // Step 5: Clear the original list
        data.Clear();

        // Step 6: Add the new array to the original list
        data.AddRange(newArray);
    }
}
