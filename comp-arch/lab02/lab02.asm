; Исходные данные
MOV AL, 0F9h    ; X1 = -7
MOV BL, 0B6h    ; X2 = 182
MOV CL, 030h    ; X3 = -208
MOV DL, 01Ah    ; X4 = 26

; --- 1) X3 = X3 + X2 ---
MOV AL, CL      ; AL = X3
ADD AL, BL      ; AL = X3 + X2
MOV CL, AL      ; CL = new X3

; --- 2) X1 / X3 ---
MOV AL, 0F9h    ; AL = X1
CBW             ; расширение знака в AX
IDIV CL         ; AX / CL -> AL=result
MOV AH, 00h     ; очистка старшего байта
MOV AL, AL      ; результат деления в AL (0)

; --- 3) X2 = X2 XOR X1 ---
MOV AL, 0F9h    ; AL = X1
XOR BL, AL      ; X2 xor X1 -> BL

; --- 4) X3 = X3 - X1 - CF ---
MOV AL, CL      ; AL = X3
SBB AL, 0F9h    ; AL = X3 - X1 - CF
MOV CL, AL      ; сохранить новый X3

; --- 5) X4 = X4 * 2^4 ---
MOV AL, DL      ; AL = X4
SHL AL, 4       ; умножение на 16
MOV DL, AL      ; сохранить новый X4
