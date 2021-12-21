
.data
    poczatkowa_kolumna dq ?
    koncowa_kolumna dq ?
    wysokosc_obrazka dq ?
    stopien dq ?

.code

Zaszumianie proc

;noise(rcx dane, rdx daneLosowe, r8 poczatkowaKolumna, r9 koncowaKolumna, [rsp + 40] wysokoscObrazka, [rsp + 48] stopien)
noise:
    push rbx
    push r12
    push r13
    push r14
    push r15

    mov r12, rcx ; r12 = dane
    mov r13, rdx ; r13 = dane losowe
    mov r14, 0   ; r14 = obecna wysokosc
    mov r15, r8  ; r15 = obecna kolumna
    
    mov r10, [rsp + 80]
    imul r10, 4         ; wysokosc obrazka * 4 bajty (rgba)

    mov r11, [rsp + 88]

    mov poczatkowa_kolumna, r8
    mov koncowa_kolumna,    r9
    mov wysokosc_obrazka,   r10
    mov stopien,            r11
    
    

height_loop:
    mov rax, r15
    mul wysokosc_obrazka ; rax = obecna kolumna * wysokosc obrazka (kolumna w tabeli jednowymiarowej)

    lea rbx, [rax + r14*4] ; rbx = rax + piksel od gory (indeks tablicy)

    mov rdi, 0
    mov dil, [r12 + rbx] ; rdi = *rbx
    mov rsi, 0
    mov sil, [r12 + rbx + 1] ; rsi = *(rbx + 1)
    mov rdx, 0
    mov dl, [r12 + rbx + 2] ; rdx = *(rbx + 2)

    call rand

    cmp rax, stopien
    jl height_loop_end

    mov cl, BYTE PTR [r13 + rbx]
    mov BYTE PTR [r12 + rbx], cl
    mov cl, BYTE PTR [r13 + rbx + 1]
    mov BYTE PTR [r12 + rbx + 1], cl
    mov cl, BYTE PTR [r13 + rbx + 2]
    mov BYTE PTR [r12 + rbx], cl

height_loop_end:
    add r14, 4 ; wysokosc+=4
    
    cmp wysokosc_obrazka, r14
    jg height_loop ; if (obecna_wysokosc < koncowa_wysokosc) height_loop();

column_loop:
    inc r15 ; kolumna++
    mov r14, 0 ; wysokosc = 0

    cmp koncowa_kolumna, r15
    jg height_loop ; if (obecna_kolumna < koncowa_kolumna) height_loop();

cleanup:
    pop r15
    pop r14
    pop r13
    pop r12
    pop rbx
    ret

rand:
    push rbx

    mov rax, rdi ; eax = a

    add rax, rsi ; eax = a + b 

    mul rdx      ; eax = (a + b) * c
   
    mov rdx, 0  
    mov rbx, 100 ; rbx = 100
    div rbx      ; edx:eax / rbx = eax | edx:eax % rbx = edx

    mov rax, rdx ; return eax
    
    pop rbx
    ret
Zaszumianie endp

Example proc
    mov r8, qword ptr [rsp + 40]
    mov r9, qword ptr [rsp + 48]
ret
Example endp
end