#include <string>
#include <iostream>

std::string Two(std::string input[], int size)
{
    int maxSize = 0;
    for (int i = 0; i < size; i++)
    {
        if (input[i].length() > maxSize) maxSize = input[i].length();
    }

    int counts[26][3];
    for (int i = 0; i < 26; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            counts[i][j] = 0;
        }
    }

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < input[i].length(); j++)
        {
            counts[input[i][j] - 'a'][j]++;
        }
    }

    std::string result = "";
    for (int i = 0; i < maxSize; i++)
    {
        char letter = 'A';
        int min = 1000000;
        for (int j = 0; j < 26; j++)
        {
            if (counts[j][i] % 2 == 1 && counts[j][i] < min)
            {
                min = counts[j][i];
                letter = (char)(j + 'a');
            }
        }
        if (letter == 'A') break;
        result += letter;
    }

    return result;
}

int main()
{
    std::string input[] = {"bac", "abc", "gif", "bac", "gif"};



    std::cout << Two(input, 5) << std::endl;
    return 0;
}