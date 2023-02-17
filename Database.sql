create table user_type (

type_name varchar(50),
type_id int PRIMARY KEY

);

create table users (

username varchar(15) NOT NULL PRIMARY KEY,
user_password varchar(10)NOT NULL,
type_id int FOREIGN KEY REFERENCES user_type (type_id)
);