; input
MOV AL, 0F9h      ; X1 = -7
MOV BX, 000B6h    ; X2 = 182
MOV CX, 0FF30h    ; X3 = -208
MOV DL, 01Ah      ; X4 = 26

; X3 = X3 + X2 
ADD CX, BX        ; CX = X3 + X2

; DX:AX = X1 / X3     
CBW               ; sign extend byte AL -> word AX
CWD               ; sign-extend word AX to  dword DX:AX (if AX<0: DX = FFFFh, else zero) - IDIV takes 32-bit DWORD DX:AX as devidend 
IDIV CX           ; (DX:AX) / CX -> AX=quotient, DX=remainder

; X2 = X2 XOR X1 
MOV AX, 0FFF9h    ; AX = X1 after IDIV
XOR BX, AX        ; BX = X2 XOR X1

; X3 = X3 - X1 - CF 
SBB CX, AX        ; CX = X3 - X1 - carry_flag

; X4 = X4 * 2^4    
MOV DX, 0001Ah    ; DX = X4 after IDIV
SHL DX, 4         ; DX = X4 * 16 (bitwise left shift)
