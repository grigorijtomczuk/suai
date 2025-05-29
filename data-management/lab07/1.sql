SELECT disks.`ID_Диска`, disks.`Название` AS 'Название диска',
    formats.`Название` AS 'Формат', genres.`Название` AS 'Жанр', disks.`Длительность`
FROM `Диски` disks
JOIN `Жанры` genres ON disks.`Жанр_ID` = genres.`ID_Жанра`
JOIN `Форматы дисков` formats ON disks.`Формат_ID` = formats.`ID_Формата`
WHERE genres.`Название` = 'Детектив';
