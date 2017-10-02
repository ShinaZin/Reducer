# Reducer
## Программа для сокращения текстов

### Функционал:
  * Сокращение слова с помощью точки
     * Пример: "Дисперсия -> Дисперс."
  * Сокращение слова с помощью тире
    * Пример: "Дисперсия -> Дисп-ия"
  * Удаление лишних пробелов и табуляций
    * Пример: "Слово1       слово2 -> Слово1 слово2"
	
### Дополнительно
  * Настройка количества слогов,  которые не подвергнутся сокращению
  * Работа с файлами
  * Работа из командной строки
  
### Использование:
    1)Reducer [имя файла]
    2)Reducer -i имя файла [необязательные ключи (-o xxx -s -n ..)]
### Ключи:
    -i имя входного файла
    -o имя выходного файла
    -s - если задан, то будут удалены повторяющиеся пробелы и табуляции
    -n - удаление всех переводов строк
    -ms число - максимальное число слогов
    -mh число - минимальное число слогов для сокращения через дефис
    -dv число - процент удаляемых гласных
