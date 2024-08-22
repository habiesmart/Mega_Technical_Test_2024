-- Oleh: Muhammad Nurul Habie Budiman (habiesmart.com)

use Mega_Technical_Test_DB

CREATE TABLE TabelPembayaran (
    NoKontrak VARCHAR(20) PRIMARY KEY,
    TglBayar DATETIME,
    JumlahBayar INT,
    KodeCabang INT,
    NoKwitansi VARCHAR(20),
    KodeMotor VARCHAR(10)
);

CREATE TABLE TabelCabang (
    KodeCabang INT PRIMARY KEY,
    NamaCabang VARCHAR(50)
);

CREATE TABLE TabelMotor (
    KodeMotor VARCHAR(10) PRIMARY KEY,
    NamaMotor VARCHAR(50)
);

CREATE TABLE ms_storage_location (
    location_id VARCHAR(10) PRIMARY KEY,
    location_name VARCHAR(100)
);

CREATE TABLE ms_user (
    user_id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_name VARCHAR(20),
    password VARCHAR(50),
    is_active BIT
);

CREATE TABLE tr_bpkb (
    agreement_number VARCHAR(100) PRIMARY KEY,
    bpkb_no VARCHAR(100),
    branch_id VARCHAR(10),
    bpkb_date DATETIME,
    faktur_no VARCHAR(100),
    faktur_date DATETIME,
    location_id VARCHAR(10),
    police_no VARCHAR(20),
    bpkb_date_in DATETIME,
    created_by VARCHAR(20),
    created_on DATETIME,
    last_updated_by VARCHAR(20),
    last_updated_on DATETIME,
    FOREIGN KEY (location_id) REFERENCES ms_storage_location(location_id)
);

insert into ms_storage_location (location_id, location_name) values('1', 'Jakarta');
insert into ms_storage_location (location_id, location_name) values('2', 'Bandung');

insert into ms_user (user_name, password, is_active) 
values
('jhonUmiro', 'admin1*', 1)
,('trisNatan', 'admin2@', 1)
,('hugoRess', 'admin3#', 0)