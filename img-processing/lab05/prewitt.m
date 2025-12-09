image=rgb2gray(imread('6.bmp'));

image_prewitt=edge(image,'prewitt', 0.2);
subplot(1,3,1);
imshow(image_prewitt);
title('Метод Превитта (0.2)');

image_prewitt=edge(image,'prewitt', 0.1);
subplot(1,3,2);
imshow(image_prewitt);
title('Метод Превитта (0.1)');

image_prewitt=edge(image,'prewitt', 0.05);
subplot(1,3,3);
imshow(image_prewitt);
title('Метод Превитта (0.05)');
