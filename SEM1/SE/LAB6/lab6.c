#include <stdlib.h>
#include <time.h>
#include <stdio.h>
#ifndef __MMU__H__
#define __MMU__H__
#define SIZE 500//65536

typedef short byte_t;
typedef int address_t;

typedef struct hole
{
    address_t adr;
    int sz;
    struct hole *next;
    struct hole *prev;
} hole_t;

typedef struct
{
    byte_t mem[SIZE];
    hole_t root; // holes list
} mem_t;

// dynamically allocates a mem_t structure and initializes its content
mem_t *initMem()
{

    mem_t *memory = malloc(SIZE);
    memory->root.sz = rand() % (200 - 1) + 1; //
    int compteur = memory->root.sz;
    memory->root.prev = NULL;
    memory->root.next = NULL;
    memory->root.adr = 0;

    
   
    while (compteur < SIZE)
    {
        int size2 = rand() % (200 - 1) + 1;
        
        if (compteur + size2 < SIZE)
        {
            compteur = compteur + size2;
            hole_t *new_hole = (hole_t *)malloc(sizeof(hole_t));
            new_hole->sz = size2;                                    // Defines randomly between 1 and 200 the size of the hole                                 
            new_hole->next = memory->root.next;                     // Insert the hole at the begining of the list
            memory->root.next = new_hole;
            new_hole->prev = &memory->root;

            if (new_hole->next != NULL)
            {
                new_hole->next->prev = new_hole;
            }
        }
        else //For the last hole, we assignate the size mannualy so that the sum of the sizes of the holes is exactly equal SIZE
        {
            size2 = SIZE - compteur;

            hole_t *new_hole = (hole_t *)malloc(sizeof(hole_t));
            new_hole->sz = size2;
            new_hole->next = memory->root.next;
            memory->root.next = new_hole;
            new_hole->prev = &memory->root;

            if (new_hole->next != NULL)
            {
                new_hole->next->prev = new_hole;
            }
            compteur = compteur + size2;
        }
    }

    hole_t *current = &memory->root;
    while (current != NULL) // We assign the addresses
    {
        if (current->prev == NULL)
        {
            current = current->next; //if it's the first hole, the address 0 has already been designed
        }
        else
        {
            current->adr = current->prev->adr + current->prev->sz; // define the address of the hole using the address of the previous hole and its size
            current = current->next;
        }
    }

    
for(int i = 0; i<255; i++){
        memory->mem[i] = 1;
    }
    return memory;
}

void print_list(hole_t *head)
{
    hole_t *current = head;

    while (current != NULL)
    {
        printf("%d\n", current->sz);
        current = current->next;
    }
}

// allocates space in bytes (byte_t) using First-Fit, Best-Fit or Worst-Fit
address_t myAlloc(mem_t *mp, int sz)
{
}

// release memory that has already been allocated previously
void myFree(mem_t *mp, address_t p, int sz);

// assign a value to a byte
void myWrite(mem_t *mp, address_t p, byte_t val);

// read memory from a byte
byte_t myRead(mem_t *mp, address_t p);

#endif

int main()
{
    srand(time(NULL));
    mem_t *mem = initMem();
    printf("%d", mem->mem[SIZE-1]);
    /*address_t adr1 = myAlloc(mem, 5);
    address_t adr2 = myAlloc(mem, 10);
    address_t adr3 = myAlloc(mem, 100);
    myFree(mem, adr2, 10);
    myFree(mem, adr1, 5);
    myWrite(mem, adr3, 543); // write on the 1stbyte
    myWrite(mem, adr3+9, 34); // write on the 10th byte
    byte_t  val1 = myRead(mem, adr3);
    byte_t val2 = myRead(mem, adr3+9); */
    //print_list(&mem->root);
}