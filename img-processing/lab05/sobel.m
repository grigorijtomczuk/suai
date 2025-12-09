image=rgb2gray(imread('6.bmp'));
subplot(3,2,1);
imshow(image);
title('Исходное изображение');

image_sobel=edge(image,'sobel',0.05);
subplot(3,2,2);
imshow(image_sobel);
title('Метод Собела (0.05)');

image_sobel=edge(image,'sobel',0.1);
subplot(3,2,3);
imshow(image_sobel);
title('Метод Собела (0.1)');

image_sobel=edge(image,'sobel',0.2);
subplot(3,2,4);
imshow(image_sobel);
title('Метод Собела (0.2)');

image_sobel=edge(image,'sobel',0.1, 'horizontal');
subplot(3,2,5);
imshow(image_sobel);
title('Метод Собела (0.1, horizontal)');

image_sobel=edge(image,'sobel',0.1, 'vertical');
subplot(3,2,6);
imshow(image_sobel);
title('Метод Собела (0.1, vertical)');
