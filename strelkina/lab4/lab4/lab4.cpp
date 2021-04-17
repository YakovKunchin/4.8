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

}

int** create_matrix(int n1, int m1)
{
	int** matrix = static_cast<int**>(malloc(sizeof(int*) * n1));
	for (int i = 0; i < n1; i++)
		matrix[i] = static_cast<int*>(malloc(sizeof(int) * m1));

	return matrix;
}

void do_work(const int size, const int pipe)
{
	int** matrix1 = create_matrix(size, size);
	int** matrix2 = create_matrix(size, size);

	randomize_matrix(matrix1, size, size);
	randomize_matrix(matrix2, size, size);

	int** result = create_matrix(size, size);

	omp_set_dynamic(0);
	omp_set_num_threads(pipe);
	clock_t begin = clock();
#pragma omp parallel for shared(matrix1, matrix2, result) private(i, j, k)

	for (int i = 0; i < size; i++)
		for (int j = 0; j < size; j++)
		{
			result[i][j] = 0;
			for (int k = 0; k < size; k++)
				result[i][j] += matrix1[i][k] * matrix2[k][j];
		}

	clock_t end = clock();
	double executionTime = static_cast<double>(end - begin) / CLOCKS_PER_SEC;
	cout <<"size: " << size << "x" << size << " pipes: " << pipe << " time: " << executionTime << endl;
}

int main() {
	srand(time(nullptr));
	
	const int sizes[5] = {100, 300, 600, 900, 1200};
	const int pipes[8] = {1, 2, 3, 4, 5, 6, 7, 8};

	for (int size : sizes)
	{
		for (int pipe : pipes)
		{
			do_work(size, pipe);
		}
	}

	return 0;
}
