CREATE DATABASE IF NOT EXISTS perusahaan;
USE perusahaan;

CREATE TABLE karyawan (
    nik VARCHAR(150) NOT NULL,
    nama VARCHAR(150) NOT NULL,
    jabatan VARCHAR(150) NOT NULL,
    alamat VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL,
    telpon VARCHAR(15) NOT NULL,
    PRIMARY KEY (nik)
) ENGINE=InnoDB;