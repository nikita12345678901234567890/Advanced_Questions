#include <string>
#include <iostream>
int main()
{
	std::string buzzez[] = { "FizzBuzz", "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14" };
	int i = 0;
	int n = 30;

Loop:
	std::cout << buzzez[((i - ((i / 15) * 15)) % 15)] << std::endl;
	i++;
	if (i < n) goto Loop;

	return 0;
}