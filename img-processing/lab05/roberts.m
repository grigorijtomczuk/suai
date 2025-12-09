image=rgb2gray(imread('6.bmp'));
subplot(2,2,1);
imshow(image);
title('Исходное изображение');

image_roberts=edge(image,'roberts',0.25);
subplot(2,2,2);
imshow(image_roberts);
title('Метод Робертса (0.25)');

image_roberts=edge(image,'roberts',0.1);
subplot(2,2,3);
imshow(image_roberts);
title('Метод Робертса (0.1)');

image_roberts=edge(image,'roberts',0.05);
subplot(2,2,4);
imshow(image_roberts);
title('Метод Робертса (0.05)');
