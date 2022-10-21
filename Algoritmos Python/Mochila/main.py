#ALGORITMO DE LA MOCHILA
#Restricciones:
# Programación entera
# Peso : Mayor valor entre todos los ítems
#Resultado: Conjunto de candidato(s)

# Ingreso de la cantidad de elementos disponibles a Cargar
n = int(input("Ingrese el número de elementos de la Mochila: "))
print('\n')

#Ingreso del Nombre de Cada elemento
nombres = []
for i in range(0, n):
  print("Ingrese el Nombre del Elemento-{}: ".format(i + 1))
  elm3 = input()
  nombres.append(elm3)

print('\n')

#Ingreso del Peso de cada elemento
pesos = []
for i in range(0, n):
  print("Ingrese el Peso del Elemento-{}: ".format(i + 1))
  elm2 = int(input())
  pesos.append(elm2)

print('\n')

#Ingreso del Beneficio de cada elemento
beneficios = []
for i in range(0, n):
  print("Ingrese el Beneficio del Elemento-{}: ".format(i + 1))
  elm = int(input())
  beneficios.append(elm)

print('\n')

#Asignando la capacidad de la mochila...
print("Capacidad de la mochila:", max(pesos))
capacidadMax = max(pesos)


def mochila(capacidadMax, pesos, beneficios, n):
  #Se crea matriz multidimensional compuesta de:
  #[] arreglo de cantidad de elementos + 1 (Filas)
  #y cada elemento de este arreglo contiene:
  #arreglo con la capacidad máxima + 1 (Columnas)
  K = [[0 for x in range(capacidadMax + 1)] for x in range(n + 1)]

  #Recorremos la cantidad de elementos de la mochila
  #Se recorren las filas
  for fila in range(n + 1):
    #Se recorren las columnas
    for columna in range(capacidadMax + 1):
      #Se inicializa la etapa y el conjunto solución en 0
      if fila == 0 or columna == 0:
        K[fila][columna] = 0
      #Valida que el peso de la etapa sea menor o igual al peso actual (columna)
      elif pesos[fila - 1] <= columna:
        #Se asigna al campo actual (etapa/peso) el mayor beneficio 
        #para llenar el peso actual respecto a la fila anterior
        K[fila][columna] = max(beneficios[fila - 1] + K[fila - 1][columna - pesos[fila - 1]],
                      K[fila - 1][columna])
      else:
        #Si no cumple ninguno de los casos
        #Se asigna el valor de la columna anterior en la misma posición de la fila actual
        K[fila][columna] = K[fila - 1][columna]

  #Retorna el valor resultante (calculo del mayor beneficio) de la matriz 
  #en la posición k[etapa Final][capacidad máxima]
  res = K[n][capacidadMax]
  print("Beneficio mayor:", res)

  w = capacidadMax
  acum = ''
  for i in range(n, 0, -1):
    if res <= 0:
      break
    if res == K[i - 1][w]:
      continue
    else:
      #Se realiza regresión en la matriz
      res = res - beneficios[i - 1]
      w = w - pesos[i - 1]

      #Se agregan a la variable "acum" los nombres de los artículos ingresados en la mochila
      index = pesos.index(pesos[i - 1])
      acum += nombres[index]

  print('Elementos Usados:', acum)

#Impresión de Ganancia
mochila(capacidadMax, pesos, beneficios, n)
