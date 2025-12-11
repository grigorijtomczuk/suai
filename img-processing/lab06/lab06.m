image=imread('img.jpg');
subplot(3,2,1);
imshow(image);
title('Исходное изображение');

image_lab = rgb2lab(image);

patch = imcrop(image_lab, [0, 64, 56, 56]);
subplot(3,2,2);
imshow(lab2rgb(patch));
title('Фрагмент шума');

color_magnitude = sqrt(sum(patch.^2, 3)); % модуль цветового вектора
color_variance = std2(color_magnitude).^2; % дисперсия (оценка разброса цвета)
dos = 16*color_variance;

% image_lab = imcrop(image_lab, [128,128,256,256]);

smoothed_lab = imbilatfilt(image_lab, dos);
smoothed_rgb = lab2rgb(smoothed_lab);
subplot(3,2,3);
imshow(smoothed_rgb);
title(['Степень сглаживания: ',num2str(dos)]);

smoothed_lab = imbilatfilt(image_lab, dos, 2);
smoothed_rgb = lab2rgb(smoothed_lab);
subplot(3,2,4);
imshow(smoothed_rgb);
title(['Степень сглаживания: ',num2str(dos),', радиус: 2'])

smoothed_lab = imbilatfilt(image_lab, dos, 4);
smoothed_rgb = lab2rgb(smoothed_lab);
subplot(3,2,5);
imshow(smoothed_rgb);
title(['Степень сглаживания: ',num2str(dos),', радиус: 4'])

smoothed_lab = imbilatfilt(image_lab, dos, 16);
smoothed_rgb = lab2rgb(smoothed_lab);
subplot(3,2,6);
imshow(smoothed_rgb);
title(['Степень сглаживания: ',num2str(dos),', радиус: 16'])

% smoothed_lab = imbilatfilt(image_lab, dos);
% smoothed_rgb = lab2rgb(smoothed_lab);
% subplot(3,2,3);
% imshow(smoothed_rgb);
% title(['Степень сглаживания: ',num2str(dos)]);
% 
% smoothed_lab = imbilatfilt(image_lab, dos*4);
% smoothed_rgb = lab2rgb(smoothed_lab);
% subplot(3,2,4);
% imshow(smoothed_rgb);
% title(['Степень сглаживания: ',num2str(dos*4)])
% 
% smoothed_lab = imbilatfilt(image_lab, dos*8);
% smoothed_rgb = lab2rgb(smoothed_lab);
% subplot(3,2,5);
% imshow(smoothed_rgb);
% title(['Степень сглаживания: ',num2str(dos*8)])
% 
% smoothed_lab = imbilatfilt(image_lab, dos*16);
% smoothed_rgb = lab2rgb(smoothed_lab);
% subplot(3,2,6);
% imshow(smoothed_rgb);
% title(['Степень сглаживания: ',num2str(dos*16)])