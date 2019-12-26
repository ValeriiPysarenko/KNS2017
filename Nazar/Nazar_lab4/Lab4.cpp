#include <iostream>
#include <cstdlib>
#include <ctime>

#define FIRST -10
#define LAST 53

using namespace std;


const size_t X = 10;


double fitness(double &n)
{
	return 62 - n - 86*n*n + 2*n*n*n;

}

void selection_max(double a[])
{
	for (size_t i = 0; i < X; ++i)
		for (size_t j = i + 1; j < X; ++j)
			if (fitness(a[j]) < fitness(a[i]))
				swap(a[i], a[j]);

	copy(a + X / 2, a + X, a);
}

void selection_min(double a[])
{
	for (size_t i = 0; i < X; ++i)
		for (size_t j = i + 1; j < X; ++j)
			if (fitness(a[j]) > fitness(a[i]))
				swap(a[i], a[j]);

	copy(a + X / 2, a + X, a);
}

double mutation_min(double &t)
{

	do { t += ((((double)(rand() % 2)) / 100 == 0.01) ? 0.1 : -0.01);
	} 
	while (t == 0 || t<FIRST || t>LAST);


	return t;
}
double mutation_max(double &t)
{

	do { t += ((((double)(rand() % 2)) / 100 == 0.01) ? 0.01 : -0.01);
	} 
	while (t == 0 || t<FIRST || t>LAST);


	return t;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));

	double data_base[X] = { 0 };
	double data_base2[X] = { 0 };


	for (int rounds = 0; rounds < 500; rounds++)
	{
		for (size_t i = 0; i < X; ++i)
			data_base[i] = mutation_max(data_base[i]);
		selection_max(data_base);
	}

	for (int rounds = 0; rounds < 500; rounds++)
	{
		for (size_t i = 0; i < X; ++i)
			data_base2[i] = mutation_min(data_base2[i]);
		selection_min(data_base2);
	}
	double ymax = fitness(data_base[4]);
	double ymin = fitness(data_base2[4]);

	cout << "����� ������������� �������� �����i�" << endl;
	cout << "������������ [�,y] �� ��i� i�����i��:" << endl;
	for (size_t i = 0; i < X; i++)
		cout << "I�����i� �" << i+1 << ": x=" << data_base[i] << ", y=" << fitness(data_base[i]) << endl;


	cout << "��� x=" << data_base[9] << endl;
	cout << "y_max=" << ymax;
	cout << endl;
	cout << endl;
	cout << "����� �i�i�������� �������� �����i�" << endl;
	cout << "������������ [�,y] �� ��i� i�����i��:" << endl;
	for (size_t i = 0; i < X; i++)
		cout << "I�����i� �" << i+1 << ": x=" << data_base2[i] << ", y=" << fitness(data_base2[i]) << endl;

	cout << "��� x=" << data_base2[9] << endl;
	cout << "y_min=" << ymin;
	cin.get();
	return 0;
}
