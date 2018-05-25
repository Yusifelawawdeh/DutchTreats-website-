// TypeScript stuff Revision
//class
//export
var StoreCustomer = /** @class */ (function () {
    //constructor
    function StoreCustomer(firstName, LastName) {
        this.firstName = firstName;
        this.LastName = LastName;
        //variable
        this.visits = 0;
    }
    //function 
    StoreCustomer.prototype.showName = function (name) {
        alert(name);
        return true;
    };
    //alternative function
    StoreCustomer.prototype.screamName = function () {
        alert(this.name);
    };
    //Tertiary function
    StoreCustomer.prototype.SayName = function () {
        alert(this.firstName + " " + this.LastName);
    };
    Object.defineProperty(StoreCustomer.prototype, "name", {
        get: function () {
            return this.ourName;
        },
        // Property
        set: function (val) {
            this.ourName = val;
        },
        enumerable: true,
        configurable: true
    });
    return StoreCustomer;
}());
//instatiate new class
//let cust = new StoreCustomer("john", "sally");
//cust.visits = 10;
//# sourceMappingURL=storecustomer.js.map