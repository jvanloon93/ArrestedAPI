CREATE DATABASE IF NOT EXISTS arrestedapidb CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Create user (change password to something secure)
CREATE USER IF NOT EXISTS 'arrestedapiuser'@'localhost' IDENTIFIED BY 'your_secure_password';
CREATE USER IF NOT EXISTS 'arrestedapiuser'@'192.168.1.182' IDENTIFIED BY 'your_secure_password';
CREATE USER IF NOT EXISTS 'arrestedapiuser'@'192.168.1.183' IDENTIFIED BY 'your_secure_password';

-- Grant privileges
GRANT ALL PRIVILEGES ON arrestedapidb.* TO 'arrestedapiuser'@'localhost';
GRANT ALL PRIVILEGES ON arrestedapidb.* TO 'arrestedapiuser'@'192.168.1.182';
GRANT ALL PRIVILEGES ON arrestedapidb.* TO 'arrestedapiuser'@'192.168.1.183';

-- Apply changes
FLUSH PRIVILEGES;

-- Show databases to verify
SHOW DATABASES; SELECT * from MYSQL.Users;

CREATE TABLE quotes (
    id INT AUTO_INCREMENT PRIMARY KEY ,
    season INT NOT NULL,
    episode INT NOT NULL,
    character_name VARCHAR(100) NOT NULL,
    quote VARCHAR(1000) NOT NULL 
);

INSERT INTO quotes (season, episode, character_name, quote)
    VALUES
    (1,2,'Tobias Funke','I mean, look at me, I''m an actor.'),
    (1,3,'Lucille Bluth','I mean, it''s one banana Michael. What could it cost? $10?'),
    (1,1,'Lucille Bluth','Look what the homosexuals have done to me.'),
    (1,1,'Boat Full of Homesexual Protestors', 'We''re here! We''re queer! We want to get married on the ocean!'),
    (1,1,'Lucille Bluth','Everything they do is so dramaic and flamboyent, it just makes me want to set myself on fire!'),
    (1,1,'Gob Bluth','Illusion Michael, a trick is something a whore does for money'),
    (1,1,'Lucille Bluth','I don''t care for Gob.'),
    (1,1,'Tobias Funke','It''s good. It''s going to be good.'),
    (1,1,'Narrator','Then, mistaking a group of garishly dressed men for pirates, Tobias boarded a van of homosexuals.'),
    (1,1,'Tobias Funke','No, I''m not --I''m not gay. No Lindsey, how many times must we have this -- No. I want to be an actor.'),
    (1,1,'George Bluth','They cannot arrest a husband and wife for the same crime...'),
    (1,1,'Gob Bluth','*creates smoke and releases a bird* That enough of a reference for you?'),
    (1,1,'George Bluth','*sitting in jail wearing a durag* I am having the time of my life!');



