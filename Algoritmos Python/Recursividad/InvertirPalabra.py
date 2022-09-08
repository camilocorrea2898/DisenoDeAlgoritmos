def InvertirPalabraIterativo(palabra):
    palabraInvertida=[]
    i = len(palabra)
    while i > 0: 
        palabraInvertida += palabra[i-1]
        i = i - 1 
        palabraInvertida = ''.join(str(x) for x in palabraInvertida)
    return palabraInvertida

def InvertirPalabraRecursivo(palabra,n):
    if 0==n:
        palabraInvertida=palabra[n]
    else:
        palabraInvertida=palabra[n]+InvertirPalabraRecursivo(palabra,n-1)
    return palabraInvertida

if __name__ == "__main__":
    palabra = input("Que palabra quieres invertir? ")
    print("La palabra ",palabra," invertida de manera recursiva es",InvertirPalabraRecursivo(palabra,len(palabra)-1))
    print("La palabra ",palabra," invertida de manera iterativa es",InvertirPalabraIterativo(palabra))