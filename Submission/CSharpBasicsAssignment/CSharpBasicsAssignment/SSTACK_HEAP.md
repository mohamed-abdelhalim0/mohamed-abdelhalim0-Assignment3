# Stack & Heap

## Diagram 1 — After line 1

```text
STACK                              HEAP
+------------------+              +---------------------------+
| o1               |              | Order                     |
| Address: 0x100   |------------->| OrderId: 1                |
+------------------+              | CustomerName: "Ali"       |
                                  | Quantity: 0                |
                                  | UnitPrice: 0               |
                                  | TotalPrice: 0              |
                                  | IsPaid: false              |
                                  | DiscountPercent: 0         |
                                  | ShippingCity: null         |
                                  | Priority: '\0'             |
                                  | ItemCode: 0                |
                                  +---------------------------+
```

After line 1, `o1` stores a reference to the new `Order` object on the heap.

---

## Diagram 2 — After line 2

```text
STACK                              HEAP
+------------------+              +---------------------------+
| o1               |              | Order                     |
| Address: 0x100   |----------+-->| OrderId: 1                |
+------------------+          |   | CustomerName: "Ali"       |
                              |   | Quantity: 0                |
+------------------+          |   | UnitPrice: 0               |
| o2               |          |   | TotalPrice: 0              |
| Address: 0x100   |----------+   | IsPaid: false              |
+------------------+              | DiscountPercent: 0         |
                                  | ShippingCity: null         |
                                  | Priority: '\0'             |
                                  | ItemCode: 0                |
                                  +---------------------------+
```

After line 2, `o2` receives the same reference as `o1`, so both point to the same heap object.

---

## Diagram 3 — After line 3

```text
STACK                              HEAP
+------------------+              +---------------------------+
| o1               |              | Order                     |
| Address: 0x100   |----------+-->| OrderId: 1                |
+------------------+          |   | CustomerName: "Ali"       |
                              |   | Quantity: 0                |
+------------------+          |   | UnitPrice: 0               |
| o2               |          |   | TotalPrice: 0              |
| Address: 0x100   |----------+   | IsPaid: true               |
+------------------+              | DiscountPercent: 0         |
                                  | ShippingCity: null         |
                                  | Priority: '\0'             |
                                  | ItemCode: 0                |
                                  +---------------------------+
```

After line 3, `IsPaid` changes to `true`, and both `o1` and `o2` still point to the same object.

---

## What would be different with structs?

If `Order` were a `struct` instead of a `class`, assigning `o2 = o1` would copy the values instead of copying a reference.

Using the `Point` struct from Part C, `p2 = p1` creates a separate copy of `p1`, so changing `p2.X` does not change `p1.X`.

Therefore, the diagram would show two separate copies of the data instead of two variables pointing to the same heap object.