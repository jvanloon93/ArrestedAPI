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

Use arrestedapidb;

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

INSERT INTO quotes (season, episode, character_name, quote)
VALUES
    (1,2,'George Bluth','There''s always money in the banana stand'),
    (1,2,'Prison Guard','No touching'),
    (1,2,'Tobias Funke','We are just ass to ankles back here'),
    (1,2,'Michael Bluth','Only thing I found in the freezer was a dead dove in a bag'),
    (1,2,'Tobias Funke','Look at me, I''m an actor. An actor for crying out loud'),
    (1,2,'Tobias Funke','In this business of show, you need to have the heart of an angle and the hide of an elephant'),
    (1,2,'Tobias Funke','Well excusseee meee'),
    (1,2,'Lucille Bluth', 'Then why don''t you marry an ice cream sandwhich'),
    (1,2,'Tobias Funke','Oh my god, we''re have a fire... sale. Oh the burning!'),
    (1,2,'Lucille Bluth','Don''t take that tone, he''s my son. I want you to make him stop calling me.'),
    (1,2,'Lindsay Funke','Did you enjoy your meal mother, you drank it fast enough.'),
    (1,2,'Lucille Bluth','Not as much as you enjoyed yours. You want your belt to buckle, not your chair.'),
    (1,2,'George Michael', 'They''re adults, they''re allowed to have fun whenever they want. We''re kids, we''re supposed to be working.'),
    (1,2,'Lucille Bluth','You might want to let that fire go out before you stick your face in it.'),
    (1,2,'Lindsay Bluth','Ah that''s funny, becasuse I was going to say you might want to lean away from that fire since you''re soaked in alcohol');
 
INSERT INTO quotes (season, episode, character_name, quote)
VALUES 
    (1,3,'Michael Bluth', 'Cornballing piece of shit!'),
    (1,3, 'Steve Holt','Steve Holt!'),
    (1,3,'Buster Bluth','*As bird flies through house* It walked on my pillow!'),
    (1,3,'Tobias Funke', 'I will be your new director!'),
    (1,3,'Tobas Funke','You are playing adults with fully formed libidos, not two young men playing grabass in the shower.'),
    (1,3,'Gob Bluth','She''s not that Mexican Mom, she''s my Mexican, and she''s Columbian or something.'),
    (1,3,'Tobias Funke','Why Tracy why!');


