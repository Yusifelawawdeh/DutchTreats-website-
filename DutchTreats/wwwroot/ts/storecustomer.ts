
// TypeScript stuff Revision

//class
//export


class StoreCustomer {
    //constructor
    constructor(private firstName: string, private LastName: string) {
    }

    //variable
    public visits: number = 0;
    private ourName: string;

    //function 
    public showName(name: string): boolean {
        alert(name);
        return true;
    }

    //alternative function
    public screamName() {
        alert(this.name);
    }

    //Tertiary function
    public SayName() {
        alert(this.firstName + " " + this.LastName);
    }

    // Property
    set name(val) {
        this.ourName = val;
    }

    get name() {
        return this.ourName;
    }
    // property
}

//instatiate new class
//let cust = new StoreCustomer("john", "sally");
//cust.visits = 10;