using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE

        // Convert words array to HashSet
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();

        // Go through each item
        foreach (var word in words)
        {
            // Skip the item if it is not in the HashSet or if its two characters repeated
            if (!wordSet.Contains(word) || word[0] == word[1])
                continue;

            // Reverse the characters
            var reversed = $"{word[1]}{word[0]}";

            // If the reversed item is also in the HashSet, 
            // Add it to results list and remove both pairs from HashSet.  
            if (wordSet.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
                wordSet.Remove(word);
                wordSet.Remove(reversed);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            string degree = fields[3];

            if (degrees.ContainsKey(degree))
            {
                degrees[degree] += 1;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE

        // Remove spaces and make both words lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // If the word length doesnt match they are not anagrams
        if (word1.Length != word2.Length)
            return false;

        // Declare dictionary for character list
        var charCount = new Dictionary<char, int>();

        // Check every character in the first word and compare it to the dictionary
        foreach (var character in word1)
        {
            // If it's present, add 1 to the value  
            if (charCount.ContainsKey(character))
                charCount[character]++;

            // Else, add it to the dictionary with a value of 1 
            else
                charCount[character] = 1;
        }

        // Check every character in the second word and compare it to the dictionary
        foreach (var character in word2)
        {
            // If the character is NOT present, or the value of the character is less or equal to 0
            // The words are not anagrams
            if (!charCount.ContainsKey(character) || charCount[character] <= 0)
                return false;

            // Else, remove one count from the value of the respective key,value pair
            else
                charCount[character]--;
        }

        // Assumming both for loops complete without early exits
        // The words are anagrams, return TRUE
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // Set size of array to number of results
        string[] result = new string[featureCollection.features.Count];

        // Iterate through each result and assign their values to the results array.
        for (int i = 0; i < featureCollection.features.Count; i++)
        {
            FeatureProperties properties = featureCollection.features[i].properties;
            result[i] = $"{properties.place} - Mag ${properties.mag}";
        }

        return result;
    }
}