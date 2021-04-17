// ReSharper disable CppUseAuto
#include <iostream>
#include <cstdlib>
#include <omp.h>
#include <ctime>
using namespace std;
void randomize_matrix(int** matrix, int n, int m) {
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			matrix[i][j] = rand() % 11;
		}
	}
	return;
}

void do_work(int n1, int m1, int**& matrix1)
{
	matrix1 = static_cast<int**>(malloc(sizeof(int*) * n1));
	for (int i = 0; i < n1; i++)
		matrix1[i] = static_cast<int*>(malloc(sizeof(int) * m1));
}

int main() {
	srand(time(nullptr));
	int n1 = 1000;
	int m1 = 500;
	int n2 = 500;
	int m2 = 1200;

	int** matrix1;
	do_work(n1, m1, matrix1);

	int** matrix2 = static_cast<int**>(malloc(sizeof(int*) * n2));
	for (int i = 0; i < n2; i++)
		matrix2[i] = static_cast<int*>(malloc(sizeof(int) * m2));

	//Генерируем случайные матрицы для умножения
	randomize_matrix(matrix1, n1, m1);
	randomize_matrix(matrix2, n2, m2);

	int** result = static_cast<int**>(malloc(sizeof(int*) * n1));;
	for (int i = 0; i < n1; i++)
		result[i] = static_cast<int*>(malloc(sizeof(int) * m2));

	//Устанавливаем число потоков
	int threadsNum = 2;
	omp_set_dynamic(0);
	omp_set_num_threads(threadsNum);
	clock_t begin = clock();
#pragma omp parallel for shared(matrix1, matrix2, result) private(i, j, k)

	for (int i = 0; i < n1; i++)
		for (int j = 0; j < m2; j++)
		{
			result[i][j] = 0;
			for (int k = 0; k < m1; k++)
				result[i][j] += (matrix1[i][k] * matrix2[k][j]);
		}


	clock_t end = clock();
	double exectionTime = static_cast<double>(end - begin) / CLOCKS_PER_SEC;
	cout << exectionTime << endl;
	return 0;
}
