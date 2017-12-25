
CREATE SCHEMA `benhvien` ;


CREATE TABLE `profile` (

`MANV` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,

`TENNV` varchar(255),

`NGAYSINH` datetime,

`GTINH` int NULL DEFAULT NULL,

`DIACHI` longtext NULL,

`SDT` int NULL DEFAULT NULL,

`CHUCVU` longtext NULL,
`enabled` boolean,

`role` int(11) NULL DEFAULT NULL,

`passwordresethash` varchar(255) CHARACTER SET utf8 NULL DEFAULT NULL,

`temppassword` varchar(255) NULL DEFAULT NULL,

PRIMARY KEY (`MANV`) 

)

AUTO_INCREMENT=1
;



CREATE TABLE `Benhnhan` (

`MABN` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,

`TENBN` varchar(255) NULL,

`NGAYSINH` date NULL,

`GTINH` int NULL,

`DCHI` longtext NULL,

`SDT` int NULL,

`CTY` longtext NULL,

`TSBENH` longtext NULL,

PRIMARY KEY (`MABN`) 

);



CREATE TABLE `pkb` (

`MAPKB` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,

`MABN` int(5) unsigned zerofill NOT NULL,

`MANV` int(5) unsigned zerofill NOT NULL,

`MABS` int(5) unsigned zerofill NOT NULL,

`TRCHUNG` longtext NULL,

`CDOAN` longtext NULL,

`NGAYKHAM` date NULL,

`LHEN` varchar(255) NULL,

`GCHU` longtext NULL,

PRIMARY KEY (`MAPKB`) 

);



CREATE TABLE `hdtk` (

`MAHDTK` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,

`MAPKB` int(5) unsigned zerofill NOT NULL,

`MANV` int(5) unsigned zerofill NOT NULL,

`NGAYLAPHD` date NULL,

`THANHTIEN` double(255,0) NULL,

PRIMARY KEY (`MAHDTK`) 

);



CREATE TABLE `cthdtk` (

`MAHDTK` int(5) unsigned zerofill,

`MADICHVU` int(5) unsigned zerofill,

PRIMARY KEY (`MAHDTK`, `MADICHVU`) 

);



CREATE TABLE `donthuoc` (

`MADT` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,

`NGAYLAPTT` date NULL,

`THANHTIEN` double(255,0) NULL,

`MAPKB` int(5) unsigned zerofill,

PRIMARY KEY (`MADT`) 

);



CREATE TABLE `ctdonthuoc` (

`MADT` int(5) unsigned zerofill,

`MATHUOC` int(5) unsigned zerofill,

`SOLUONG` int(255) NULL,

`CACHDUNG` varchar(255) NULL,

PRIMARY KEY (`MADT`, `MATHUOC`) 

);



CREATE TABLE `thuoc` (

`MATHUOC` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,

`TENTHUOC` varchar(255) NULL,

`SOLUONGCON` varchar(255) NULL,

PRIMARY KEY (`MATHUOC`) 

);



CREATE TABLE `dichvu` (

`MADICHVU` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,

`TENDICHVU` longtext NULL,

PRIMARY KEY (`MADICHVU`) 

);



CREATE TABLE `dongiathuoc` (

`MANV` int(5) unsigned zerofill,

`MATHUOC` int(5) unsigned zerofill,

`DONGIA` double NULL,

PRIMARY KEY (`MANV`) 

);



CREATE TABLE `dongiadichvu` (

`MADV` int(5) unsigned zerofill,

`MANV` int(5) unsigned zerofill,

`GIADICHVU` double NULL,

PRIMARY KEY (`MADV`, `MANV`) 

);






ALTER TABLE `ctdonthuoc` ADD CONSTRAINT `CTĐONTHUOC` FOREIGN KEY (`MADT`) REFERENCES `donthuoc` (`MADT`);

ALTER TABLE `hdtk` ADD CONSTRAINT `MAPKB` FOREIGN KEY (`MAPKB`) REFERENCES `pkb` (`MAPKB`);

ALTER TABLE `hdtk` ADD CONSTRAINT `MANV_HDTK` FOREIGN KEY (`MANV`) REFERENCES `profile` (`MANV`);

ALTER TABLE `cthdtk` ADD CONSTRAINT `MAHDTK` FOREIGN KEY (`MAHDTK`) REFERENCES `hdtk` (`MAHDTK`);

ALTER TABLE `pkb` ADD CONSTRAINT `MABN_PKB` FOREIGN KEY (`MABN`) REFERENCES `Benhnhan` (`MABN`);

ALTER TABLE `pkb` ADD CONSTRAINT `MANV_PKB_2` FOREIGN KEY (`MANV`) REFERENCES `profile` (`MANV`);

ALTER TABLE `pkb` ADD CONSTRAINT `MABS_PKB_2` FOREIGN KEY (`MABS`) REFERENCES `profile` (`MANV`);

ALTER TABLE `ctdonthuoc` ADD CONSTRAINT `THUOC` FOREIGN KEY (`MATHUOC`) REFERENCES `thuoc` (`MATHUOC`);

ALTER TABLE `cthdtk` ADD CONSTRAINT `MADV` FOREIGN KEY (`MADICHVU`) REFERENCES `dichvu` (`MADICHVU`);

ALTER TABLE `dongiathuoc` ADD CONSTRAINT `MATHUOC` FOREIGN KEY (`MATHUOC`) REFERENCES `thuoc` (`MATHUOC`);

ALTER TABLE `dongiathuoc` ADD CONSTRAINT `manv` FOREIGN KEY (`MANV`) REFERENCES `profile` (`MANV`);

ALTER TABLE `dongiadichvu` ADD CONSTRAINT `MADICHVU` FOREIGN KEY (`MADV`) REFERENCES `dichvu` (`MADICHVU`);

ALTER TABLE `dongiadichvu` ADD CONSTRAINT `MANV_DGDV` FOREIGN KEY (`MANV`) REFERENCES `profile` (`MANV`);

ALTER TABLE `donthuoc` ADD CONSTRAINT `MAPKB_DT` FOREIGN KEY (`MAPKB`) REFERENCES `pkb` (`MAPKB`);




/* User */

insert into profile(TENNV, NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled,role,temppassword) values('h','0000-00-00',1,'12323hjgjhg',099898, 'h',1,2,'11212324');

select * from `profile`

