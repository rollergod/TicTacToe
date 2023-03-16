# TicTacToe

тестовое задание от компании "Sense Capital"

## Структура папок

Provide an overview of the directory structure and files, for example:
```bash
├───TicTacToe.Api
│   ├───Controllers
│   ├───Helpers
│   ├───Interfaces
│   ├───Models
│   │   ├───Errors
│   │   │   └───Exceptions
│   │   └───Intefaces
│   ├───Properties
│   └───Services
└───TicTacToe.Console
    ├───Models
    │   └───Intefaces
```
## Запуск приложения

Скачать либо склонировать проект. Запустить .sln файл в папке проекта. В среде разработки запутсить проект(CTRL+F5)

## О приложении

REST api для игры крестики нолики.

Апи имеет 3 endpoint`а

![image](https://user-images.githubusercontent.com/91565374/225708103-4d2c3e4d-b5e5-4728-878c-50486ad74e2b.png)

* *get* **/api/game/turn** - возвращает ход игрока - X или O.
* *post* **/api/game** - принимает два параметра - координата по оси x и коордитана по оси y. Два раза одни и те же координаты указывать нельзя.
* *post* **/api/game/new-game** - создает новую игру

## Пример ввода координат

**Request:**
```json
POST /game HTTP/1.1
Accept: application/json
Content-Type: application/json
Content-Length: xy

{
    "xCord": "1",
    "yCord": "1" 
}
```
**Successful Response:**
```json
HTTP/1.1 200 OK
Server: TicTacToe
Content-Type: application/json
Content-Length: xy

{
   "Ход сделан"
}

```
**Failed Response:**
```json
HTTP/1.1 404 BadRequest
Server: TicTacToe
Content-Type: application/json
Content-Length: xy

{
    "code": 404,
    "message": "bad request",
    "resolve": "Координата с позицией x и y занята"
}

HTTP/1.1 404 BadRequest
Server: TicTacToe
Content-Type: application/json
Content-Length: xy

{
    "code": 404,
    "message": "bad request",
    "resolve": "Координаты выходят за пределы таблицы"
}

``` 

