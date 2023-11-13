# BookApi
## _Prerequsites_
- Docker
## Run

Clone project
```sh
git clone https://github.com/ZaharKaras/BookApi.git
```
Go to Library
```sh
cd Library
```
Go to console
```sh
docker compose up
```
Go to Web Browser
```sh
http://localhost:8088/swagger/index.html
```

## Api 

### Auth

| References |Parameters | description |
| ------ | ------ | -----|
| POST/register | name, password | registrate user |
| POST/login | name, password | login user, get bearer token |

### Put bearer token
![image](https://github.com/ZaharKaras/BookApi/assets/93844318/8aa013d4-fd62-422c-8081-504542b09353)


### Books
| References |Parameters | description |
| ------ | ------ | -----|
| GET/api/Books,  | | get all books |
| POST/api/Books | bookDto | create book |
| PUT/api/Books | id, book | update book's info |
| GET/api/Books/{id}| id | get book by id |
| DELETE/api/Books/{id} | id | delete book |
| GET/api/Books/{isbn} | isbn | get book by isbn |
