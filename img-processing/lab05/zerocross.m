image=rgb2gray(imread('6.bmp'));

image_zerocross=edge(image,'zerocross');
subplot(1,3,1);
imshow(image_zerocross);
title('Метод zerocross');
