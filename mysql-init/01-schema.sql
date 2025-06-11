CREATE TABLE IF NOT EXISTS Employees (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    middle_name VARCHAR(100),
    position TINYINT UNSIGNED NOT NULL,
    birth_date DATE NOT NULL,
    CONSTRAINT chk_position CHECK (position BETWEEN 1 AND 2)
);

CREATE TABLE IF NOT EXISTS Contractors (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE,
    inn BIGINT UNSIGNED NOT NULL UNIQUE,
    curator_id INT UNSIGNED,
    FOREIGN KEY (curator_id) REFERENCES Employees(id)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS Orders (
    id CHAR(36) PRIMARY KEY DEFAULT (UUID()),
    order_date DATETIME NOT NULL,
    amount DECIMAL(11, 2) NOT NULL,
    employee_id INT UNSIGNED NOT NULL,
    contractor_id INT UNSIGNED NOT NULL,
    FOREIGN KEY (employee_id) REFERENCES Employees(id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE,
    FOREIGN KEY (contractor_id) REFERENCES Contractors(id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
);

CREATE INDEX idx_orders_employee ON Orders(employee_id);
CREATE INDEX idx_orders_contractor ON Orders(contractor_id);
CREATE INDEX idx_contractors_curator ON Contractors(curator_id);

