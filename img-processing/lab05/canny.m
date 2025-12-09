image=rgb2gray(imread('6.bmp'));

% Подбор нижнего порога

image_canny=edge(image,'canny', [0.03,0.2], 0.5);
subplot(3,3,1)
imshow(image_canny);
title('Метод Канни ([0.03,0.2], 0.5)');

image_canny=edge(image,'canny', [0.06,0.2], 0.5);
subplot(3,3,2)
imshow(image_canny);
title('Метод Канни ([0.06,0.2], 0.5)');

image_canny=edge(image,'canny', [0.09,0.2], 0.5);
subplot(3,3,3)
imshow(image_canny);
title('Метод Канни ([0.09,0.2], 0.5)');

% Подбор верхнего порога

image_canny=edge(image,'canny', [0.09,0.2], 0.5);
subplot(3,3,4)
imshow(image_canny);
title('Метод Канни ([0.09,0.2], 0.5)');

image_canny=edge(image,'canny', [0.09,0.25], 0.5);
subplot(3,3,5)
imshow(image_canny);
title('Метод Канни ([0.09,0.25], 0.5)');

image_canny=edge(image,'canny', [0.09,0.3], 0.5);
subplot(3,3,6)
imshow(image_canny);
title('Метод Канни ([0.09,0.3], 0.5)');

% Подбор стандартного отклонения сглаживающего фильтра

image_canny=edge(image,'canny', [0.09,0.25], 0.33);
subplot(3,3,7)
imshow(image_canny);
title('Метод Канни ([0.09,0.25], 0.33)');

image_canny=edge(image,'canny', [0.09,0.25], 0.67);
subplot(3,3,8)
imshow(image_canny);
title('Метод Канни ([0.09,0.25], 0.67)');

image_canny=edge(image,'canny', [0.09,0.25], 0.9);
subplot(3,3,9)
imshow(image_canny);
title('Метод Канни ([0.09,0.25], 0.9)');
