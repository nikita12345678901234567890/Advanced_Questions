#include <string>
#include <iostream>
int main()
{
	std::string buzzez[] = { "", "Fizz", "Buzz", "FizzBuzz" };
	int i = 0;
	int n = 30;
	std::string output = "";

Loop:
	
	int three = i % 3;


	i++;
	if (i < n) goto Loop;

	return 0;
}