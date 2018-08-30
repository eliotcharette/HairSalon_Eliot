# _HairSalon_

#### _A Webapp that *replicates a hair salon where the owner can add stylists, and each stylists has their own clients*, July 20, 2018_

#### By _**Eliot Charette**_

## Description

_This website was created to *Replicate a hair salon.*.
Specs:
1. *Add and see a list of the stylists in the salon*
2. *Select a stylist and see their details and clients that belong to the stylist*
3. *Add clients to a stylist once that stylist is hired*
4. *Add and see a list of specialties*
5. *Add and see a list of Clients*
6. *Add a specialty to a stylist*
7. *Add a stylist to a specialty*
8. *Edit the name of a stylist*
9. *Delete stylists and clients*_

## Setup/Installation Requirements

_> CREATE DATABASE eliot_charette;
> USE eliot_charette;
> CREATE TABLE stylists (id serial PRIMARY KEY, stylist VARCHAR(255));
> CREATE TABLE clients (id serial PRIMARY KEY, client VARCHAR(255));
> CREATE TABLE specialties (id serial PRIMARY KEY, specialty VARCHAR(255));
> CREATE TABLE specialties_stylists (id serial PRIMARY KEY, specialty_id INT, stylist_id INT);

Go to Operations:
> Copy database (structure only) rename to eliot_charette_test;

 Double click the icon in your folder
   Open the MAMP server and import the database
   Navigate to the HairSalon folder and dotnet restore and then dotnet run_
## Known Bugs

_No known bugs._

## Support and contact details

_Eliot Charette email: eliotcharette@gmail.com_

## Technologies Used

_Created with Atom editor, using .net framework.  Use any browser to view._

### License

*No license required*

Copyright (c) 2018 **_Eliot Charette_**
