; input
MOV AL, 0F9h      ; X1
MOV BX, 000B6h    ; X2
MOV CX, 0FF30h    ; X3
MOV DX, 0001Ah    ; X4

; X3 = X3 + X2 
ADD CX, BX        ; CX = X3 + X2

; DX:AL = X1 / X3     
CBW
CWD               ; sign-extend AL in DX:AX (if AL<0: DX = FFFFh, else zero) - IDIV takes 32-bit DX:AL as devidend 
IDIV CX           ; (DX:AX) / CX -> AX=quotient, DX=remainder

; X2 = X2 XOR X1 
MOV AL, 0F9h      ; AL = X1 after IDIV
XOR BX, AX        ; BX = X2 XOR X1

; X3 = X3 - X1 - CF 
SBB CX, AX        ; CX = X3 - X1 - carry_flag

; X4 = X4 * 2^4    
MOV DX, 0001Ah    ; DX = X4 after IDIV
SHL DX, 4         ; DX = X4 * 16 (bitwise left shift)
