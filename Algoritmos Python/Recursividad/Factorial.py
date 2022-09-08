def factorialIterativo(numero):
    factorial=1
    i=1
    while(i<=numero):
        factorial = i*factorial
        i=i+1
    return factorial

def factorialRecursivo(numero):
    if(numero == 0 or numero == 1):
        return 1
    else:
        return numero * factorialRecursivo(numero-1)

if __name__ == "__main__":
    try:
        num = int(input("De que numero quieres saber el factorial? "))
        if(num < 0):
            print("El numero debe ser mayor o igual a 0")
        else:
            print("El factorial de ",num," de manera recursiva es",factorialRecursivo(num))
            print("El factorial de ",num," de manera interativa es",factorialIterativo(num))
    except:
        print("Se espera un numero")