
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
`enabled` int DEFAULT 1,

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

`MANV` int(5) unsigned zerofill NOT NULL,

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

`DONGIA` double NULL,

`MANV` int(5) unsigned zerofill,
`enabled` int DEFAULT 1,

PRIMARY KEY (`MATHUOC`) 

);





CREATE TABLE `dichvu` (

`MADV` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,

`TENDICHVU` longtext NULL,

`MANV` int(5) unsigned zerofill,

`GIADICHVU` double NULL,

`enabled` int DEFAULT 1,

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


ALTER TABLE `thuoc` ADD CONSTRAINT `manv` FOREIGN KEY (`MANV`) REFERENCES `profile` (`MANV`);


ALTER TABLE `dichvu` ADD CONSTRAINT `MANV_DGDV` FOREIGN KEY (`MANV`) REFERENCES `profile` (`MANV`);

ALTER TABLE `donthuoc` ADD CONSTRAINT `MAPKB_DT` FOREIGN KEY (`MAPKB`) REFERENCES `pkb` (`MAPKB`);

ALTER TABLE `donthuoc` ADD CONSTRAINT `MANV_DT` FOREIGN KEY (`MANV`) REFERENCES `profile` (`MANV`);


select hdtk.MAHDTK , hdtk.MAPKB, hdtk.NGAYLAPHD, hdtk.THANHTIEN, profile.TENNV   from `hdtk`, `profile` where NGAYLAPHD >= '2017-05-05' and  NGAYLAPHD <= '2017-08-05' and profile.MANV = hdtk.MANV ;

select donthuoc.MADT , donthuoc.MAPKB, donthuoc.NGAYLAPTT, donthuoc.THANHTIEN, profile.TENNV   from `donthuoc`, `profile` where NGAYLAPTT >= '2017-05-05' and  NGAYLAPTT <= '2017-08-05' and profile.MANV = donthuoc.MANV ;


select MONTH(NGAYLAPHD) AS THANG, Sum(THANHTIEN) AS DOANHTHU from `hdtk` where YEAR(NGAYLAPHD) = '2017' group by MONTH(NGAYLAPHD) order by THANG;

select MONTH(NGAYLAPTT) AS THANG, Sum(THANHTIEN) AS DOANHTHU from `donthuoc` where YEAR(NGAYLAPTT) = '2017' group by MONTH(NGAYLAPTT) order by THANG;


/* User */
/*Profile*/
insert into profile(TENNV, NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled,role,temppassword) values('Hàng Tuấn Thiên','12-01-1998',1,'12323hjgjhg',099898, 'h',1,0,'123456');
insert into profile(TENNV, NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled,role,temppassword) values('Đỗ Trung Quốc','12-01-1998',1,'12323hjgjhg',099898, 'h',1,1,'123456');
insert into profile(TENNV, NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled,role,temppassword) values('Nguyễn Anh Dũ','12-01-1998',1,'12323hjgjhg',099898, 'h',1,2,'123456');
insert into profile(TENNV, NGAYSINH, GTINH, DIACHI, SDT, CHUCVU, enabled,role,temppassword) values('Lê Văn Cường','12-01-1998',1,'12323hjgjhg',099898, 'h',1,0,'123456');
select * from `profile`;

/*
update profile set TENNV = "+TENNV +", NGAYSINH = "12/01/1996", GTINH = true, DIACHI = "+DIACHI+", SDT = 01234567, CHUCVU = "+CHUCVU+", enabled = 1,role = "1",temppassword = "+temppassword+" where MANV = "2"
;


*/
select * from donthuoc;
SELECT * FROM profile WHERE MANV = 2 and temppassword ='123456';
INSERT INTO `benhvien`.`donthuoc` ( `NGAYLAPTT`, `THANHTIEN`, `MAPKB`, `MANV`) VALUES ('2017-05-15','180000','1', '1');
INSERT INTO `benhvien`.`donthuoc` ( `NGAYLAPTT`, `THANHTIEN`, `MAPKB`, `MANV`) VALUES ('2017-05-15','170000','2', '1');
INSERT INTO `benhvien`.`donthuoc` ( `NGAYLAPTT`, `THANHTIEN`, `MAPKB`, `MANV`) VALUES ('2017-05-15','160000','3', '1');
INSERT INTO `benhvien`.`donthuoc` ( `NGAYLAPTT`, `THANHTIEN`, `MAPKB`, `MANV`) VALUES ('2017-05-15','150000','4', '1');
INSERT INTO `benhvien`.`donthuoc` ( `NGAYLAPTT`, `THANHTIEN`, `MAPKB`, `MANV`) VALUES ('2017-05-15','140000','5', '1');
/*insert data bao cao*/
INSERT INTO `benhvien`.`Benhnhan` (`TENBN`, `NGAYSINH`, `GTINH`, `DCHI`, `SDT`, `CTY`, `TSBENH`, `enabled`) VALUES ('B', '1996-05-20', '1', 'Ho Chi Minh', '123456', 'Ho Chi Minh', 'B', '0');
INSERT INTO `benhvien`.`Benhnhan` (`TENBN`, `NGAYSINH`, `GTINH`, `DCHI`, `SDT`, `CTY`, `TSBENH`, `enabled`) VALUES ('Nguyễn A', '1996-05-20', '1', 'Ho Chi Minh', '123456', 'Ho Chi Minh', 'B', '0');
INSERT INTO `benhvien`.`Benhnhan` (`TENBN`, `NGAYSINH`, `GTINH`, `DCHI`, `SDT`, `CTY`, `TSBENH`, `enabled`) VALUES ('Nguyễn B', '1996-05-20', '1', 'Ho Chi Minh', '123456', 'Ho Chi Minh', 'B', '0');
INSERT INTO `benhvien`.`Benhnhan` (`TENBN`, `NGAYSINH`, `GTINH`, `DCHI`, `SDT`, `CTY`, `TSBENH`, `enabled`) VALUES ('Nguyễn C', '1996-05-20', '1', 'Ho Chi Minh', '123456', 'Ho Chi Minh', 'B', '0');
INSERT INTO `benhvien`.`Benhnhan` (`TENBN`, `NGAYSINH`, `GTINH`, `DCHI`, `SDT`, `CTY`, `TSBENH`, `enabled`) VALUES ('Nguyễn D', '1996-05-20', '1', 'Ho Chi Minh', '123456', 'Ho Chi Minh', 'B', '0');

INSERT INTO `benhvien`.`pkb` (`MABN`, `MANV`, `MABS`, `TRCHUNG`, `CDOAN`, `NGAYKHAM`, `LHEN`, `GCHU`) VALUES ('1', '1', '2', 'Khùng', 'Sắp chết', '2017-05-05', 'dasdaa', 'asdasdad');
INSERT INTO `benhvien`.`pkb` (`MABN`, `MANV`, `MABS`, `TRCHUNG`, `CDOAN`, `NGAYKHAM`, `LHEN`, `GCHU`) VALUES ('2', '1', '2', 'Khùng', 'Sắp chết', '2017-05-05', 'dasdaa', 'asdasdad');
INSERT INTO `benhvien`.`pkb` (`MABN`, `MANV`, `MABS`, `TRCHUNG`, `CDOAN`, `NGAYKHAM`, `LHEN`, `GCHU`) VALUES ('3', '1', '2', 'Khùng', 'Sắp chết', '2017-05-05', 'dasdaa', 'asdasdad');
INSERT INTO `benhvien`.`pkb` (`MABN`, `MANV`, `MABS`, `TRCHUNG`, `CDOAN`, `NGAYKHAM`, `LHEN`, `GCHU`) VALUES ('4', '1', '2', 'Khùng', 'Sắp chết', '2017-05-05', 'dasdaa', 'asdasdad');
INSERT INTO `benhvien`.`pkb` (`MABN`, `MANV`, `MABS`, `TRCHUNG`, `CDOAN`, `NGAYKHAM`, `LHEN`, `GCHU`) VALUES ('5', '1', '2', 'Khùng', 'Sắp chết', '2017-05-05', 'dasdaa', 'asdasdad');

INSERT INTO `benhvien`.`hdtk` (`MAPKB`, `MANV`, `NGAYLAPHD`, `THANHTIEN`) VALUES ('1', '1', '2017-05-15', '180000');
INSERT INTO `benhvien`.`hdtk` (`MAPKB`, `MANV`, `NGAYLAPHD`, `THANHTIEN`) VALUES ('2', '1', '2017-06-05', '160000');
INSERT INTO `benhvien`.`hdtk` (`MAPKB`, `MANV`, `NGAYLAPHD`, `THANHTIEN`) VALUES ('3', '1', '2017-07-05', '140000');
INSERT INTO `benhvien`.`hdtk` (`MAPKB`, `MANV`, `NGAYLAPHD`, `THANHTIEN`) VALUES ('4', '1', '2017-08-05', '150000');
INSERT INTO `benhvien`.`hdtk` (`MAPKB`, `MANV`, `NGAYLAPHD`, `THANHTIEN`) VALUES ('5', '1', '2017-09-05', '170000');
/*DichVu*/

insert into dichvu(`TENDICHVU`,`MANV`, `GIADICHVU`, `enabled`) values('Khám tổng quát',1,300000, 1);
insert into dichvu(`TENDICHVU`,`MANV`, `GIADICHVU`, `enabled`) values('Khám nội soi 1',1,200000, 1);
insert into dichvu(`TENDICHVU`,`MANV`, `GIADICHVU`, `enabled`) values('Siêu âm lồng ngực',1,400000, 1);


insert into dichvu(`TENDICHVU`,`MANV`, `GIADICHVU`) values('Khám nội soi 1',1,300000);
insert into dichvu(`TENDICHVU`,`MANV`, `GIADICHVU`) values('Siêu âm lồng ngực',2,400000);

SELECT * from dichvu;

/*Thuoc*/

insert into thuoc(TENTHUOC,SOLUONGCON,DONGIA, MANV) values ('Paracetamol', 50, 50000,1);
insert into thuoc(TENTHUOC,SOLUONGCON,DONGIA, MANV) values ('Acerin', 100, 80000,1);
insert into thuoc(TENTHUOC,SOLUONGCON,DONGIA,MANV) values ('Benzel Dioxit', 50, 50000,1);
select * from thuoc;
