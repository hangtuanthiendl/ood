
CREATE SCHEMA `benhvien` ;


CREATE TABLE `profile` (

`MANV` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,

`TENNV` varchar(255),

`NGAYSINH` varchar(10),

`GTINH` int NULL DEFAULT NULL,

`DIACHI` longtext NULL,

`SDT` int NULL DEFAULT NULL,

`CHUCVU` longtext NULL,
`enabled` int DEFAULT 2,

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
`enabled` int DEFAULT 0,

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






CREATE TABLE `dongiathuoc` (

`MANV` int(5) unsigned zerofill,

`MATHUOC` int(5) unsigned zerofill,

`DONGIA` double NULL,

PRIMARY KEY (`MANV`) 

);



CREATE TABLE `dichvu` (

`MADV` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,

`TENDICHVU` longtext NULL,

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

ALTER TABLE `cthdtk` ADD CONSTRAINT `MADV` FOREIGN KEY (`MADICHVU`) REFERENCES `dichvu` (`MADV`);

ALTER TABLE `dongiathuoc` ADD CONSTRAINT `MATHUOC` FOREIGN KEY (`MATHUOC`) REFERENCES `thuoc` (`MATHUOC`);

ALTER TABLE `dongiathuoc` ADD CONSTRAINT `manv` FOREIGN KEY (`MANV`) REFERENCES `profile` (`MANV`);


ALTER TABLE `dichvu` ADD CONSTRAINT `MANV_DGDV` FOREIGN KEY (`MANV`) REFERENCES `profile` (`MANV`);

ALTER TABLE `donthuoc` ADD CONSTRAINT `MAPKB_DT` FOREIGN KEY (`MAPKB`) REFERENCES `pkb` (`MAPKB`);




/* User */
/*Profile*/
insert into profile(TENNV, NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled,role,temppassword) values('Hàng Tuấn Thiên','12-01-1998',1,'12323hjgjhg',099898, 'h',1,0,'123456');
insert into profile(TENNV, NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled,role,temppassword) values('Đỗ Trung Quốc','12-01-1998',1,'12323hjgjhg',099898, 'h',1,1,'123456');
insert into profile(TENNV, NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled,role,temppassword) values('Nguyễn Anh Dũ','12-01-1998',1,'12323hjgjhg',099898, 'h',1,2,'123456');
insert into profile(TENNV, NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled,role,temppassword) values('Lê Văn Cường','12-01-1998',1,'12323hjgjhg',099898, 'h',1,0,'123456');
select * from `profile`;


update profile set TENNV = "+TENNV +", NGAYSINH = "12/01/1996", GTINH = true, DIACHI = "+DIACHI+", SDT = 01234567, CHUCVU = "+CHUCVU+", enabled = 1,role = "1",temppassword = "+temppassword+" where MANV = "2"
;


SELECT * FROM profile WHERE MANV = 2 and temppassword ='123456';

/*DichVu*/

insert into dichvu(`TENDICHVU`,`MANV`, `GIADICHVU`) values('Khám tổng quát',1,200000);

SELECT * from dichvu;
