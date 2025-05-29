SELECT disks.`ID_Диска`, disks.`Название` AS 'Название диска',
       users.`Имя` AS 'Владелец',
       formats.`Название` AS 'Формат', genres.`Название` AS 'Жанр',
       borrows.`Дата_Взятия`, borrows.`Дата_Возврата`,
       CASE borrows.`Статус_Возврата` 
           WHEN 1 THEN 'Возвращено' 
           ELSE 'Не возвращено' 
       END AS 'Статус возврата'
FROM `Заимствование дисков` borrows
JOIN `Диски` disks ON borrows.`Диск_ID` = disks.`ID_Диска`
JOIN `Форматы дисков` formats ON disks.`Формат_ID` = formats.`ID_Формата`
JOIN `Жанры` genres ON disks.`Жанр_ID` = genres.`ID_Жанра`
JOIN `Пользователи` users ON borrows.`Пользователь_ID` = users.`ID_Пользователя`
