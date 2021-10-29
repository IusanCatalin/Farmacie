# Farmacie

Comenzi sql:


#creeare tabela - CREATE TABLE `farmacie`.`medicamente` ( `nume` VARCHAR(50) NOT NULL , `cantitate` INT NOT NULL , `analgezic` BOOLEAN NOT NULL , `anabolizant` BOOLEAN NOT NULL , `vitamina` BOOLEAN NOT NULL , UNIQUE `med_name` (`nume`)) ENGINE = InnoDB;
#inserare in medicamente - INSERT INTO `medicamente` (`nume`, `cantitate`, `analgezic`, `anabolizant`, `vitamina`) VALUES ('Minina', '99', '1', '1', '1');


ex1.
#comenzi SELECT * FROM `comenzi` WHERE farmacie='Dona' and data BETWEEN '2021-08-01' AND '2021-08-31' 

#numarare comenzi in august SELECT COUNT(id) FROM `comenzi` WHERE farmacie='Dona' and data BETWEEN '2021-08-01' AND '2021-08-31' 

#suma comenzilor in august(814,89) SELECT SUM(medicamente.pret * comenzi.cantitate) from medicamente inner JOIN comenzi ON medicamente.nume = comenzi.medicament where comenzi.data BETWEEN '2021-08-01' and '2021-08-31' and comenzi.farmacie='Dona'

#valoare media comenzilor in august(203,7225) SELECT AVG(medicamente.pret * comenzi.cantitate) from medicamente inner JOIN comenzi ON medicamente.nume = comenzi.medicament where comenzi.data BETWEEN '2021-08-01' and '2021-08-31' and comenzi.farmacie='Dona'

ex2.
#comenzi de antibiotice a plasat farmacia Vlad in 2021 SELECT comenzi.farmacie, comenzi.medicament, medicamente.analgezic, medicamente.anabolizant, medicamente.vitamina FROM comenzi inner JOIN medicamente on comenzi.medicament=medicamente.nume WHERE comenzi.farmacie = 'Vlad' and medicamente.antibiotic=1 and comenzi.data BETWEEN '2021-01-01' and '2021-12-31'

#count SELECT COUNT(comenzi.id) FROM comenzi inner JOIN medicamente on comenzi.medicament=medicamente.nume WHERE comenzi.farmacie = 'Vlad' and medicamente.antibiotic=1 and comenzi.data BETWEEN '2021-01-01' and '2021-12-31' 

ex3.
#farmacia care a comandat cel mai mult in 2021 
SELECT SUM(medicamente.pret * comenzi.cantitate), comenzi.farmacie from medicamente inner JOIN comenzi ON medicamente.nume = comenzi.medicament where comenzi.data BETWEEN '2021-01-01' and '2021-12-31' GROUP BY comenzi.farmacie ASC

ex4?
raport fiecare medicament cant/farmacie SELECT medicament, SUM(cantitate), farmacie from comenzi GROUP by medicament, farmacie


![database_diagram](https://user-images.githubusercontent.com/62466618/139476970-affe296e-8122-4346-9e8c-96dc2e2cd2cc.png)




![raport](https://user-images.githubusercontent.com/62466618/139477365-61f2c96d-dcee-40b7-bdee-d77e9d8e4594.png)






