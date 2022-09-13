def fibonacci_iterativo(n):
	a = 0
	b = 1
	for i in range(n - 1):
		a, b = b, a + b
	return b

def fibonacci_recursivo(n):
	if n == 0:
		return 0
	elif n == 1:
		return 1
	else:
		return fibonacci_recursivo(n - 2) + fibonacci_recursivo(n - 1)
	return  fibonacci_recursivo(10)

if __name__ == "__main__":
	num = int(input("Numero a calcular de Fibonacci? "))
	print("La ultima cifra de fibonacci ",num,"  de manera recursiva es",fibonacci_recursivo(num))
	print("La ultima cifra de fibonacci ",num,"  de manera iterativa es",fibonacci_iterativo(num))