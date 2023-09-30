new Vue({
    el: "#booking-form",
    data: {
        adult: 0,
        child: 0,
        adultPrice: 0,
        childPrice: 0,
        transferPrice: 0,
        totalAdultPrice: 0,
        totalChildPrice: 0,
        totalTransferPrice: 0,
        totalPrice: 0,
        couponCode: '',
        TotalAfterDiscount: 0,   
        isCouponApplied: false
    },
    methods: {
        getTotalPrice: function (event) {
            if (this.adult) {
                var selectedOption = event.target.options[event.target.selectedIndex];
                var price = parseFloat(selectedOption.dataset.price);
                this.transferPrice = parseFloat(price);
                this.totalAdultPrice = this.adult * this.adultPrice;
                this.totalChildPrice = this.child * this.childPrice;
                this.totalTransferPrice = (this.adult * this.transferPrice) + (this.child * this.transferPrice);
                this.totalPrice = `${this.totalAdultPrice + this.totalChildPrice + this.totalTransferPrice}`;
                $("#priceDetails").slideDown();
            } else {
                alert("Please select the number of adults first");
            }
        },
        applyCoupon() {
            const instance = this;

            axios.get("/api/coupon/" + this.couponCode)
                .then((response) => {
                    if (response.status === 200) {
                        // Coupon retrieval was successful
                        const coupon = response.data;
                        toastr.success(`You get ${coupon.discountPercentage}% off`);

                        const totalPrice = instance.totalPrice; // Get the current total price
                        const discountAmount = totalPrice *(coupon.discountPercentage/100);
                        instance.TotalAfterDiscount = totalPrice - discountAmount;
                        instance.isCouponApplied = true;
                    
                    } else {
                        // Coupon retrieval failed
                        toastr.error("Failed to retrieve coupon.");
                    }
                })
                .catch((error) => {
                    // Error occurred during the request
                    toastr.error("No discount found for this coupon.");
                });
        },
    },
    mounted: function () {
        this.$nextTick(function () {
            $("#priceDetails").slideUp();          
            this.adultPrice = parseFloat($("#adult-price").val());
            this.childPrice = parseFloat($("#child-price").val());
        });
    },
    watch: {
        adult: function (newValue, oldValue) {
            if (newValue !== oldValue) {
                this.totalAdultPrice = this.adult * this.adultPrice;
                this.totalTransferPrice = (this.adult * this.transferPrice) + (this.child * this.transferPrice);
                this.totalPrice = `${this.totalAdultPrice + this.totalChildPrice + this.totalTransferPrice}`;
            }
        },
        child: function (newValue, oldValue) {
            if (newValue !== oldValue) {
                this.totalChildPrice = this.child * this.childPrice;
                this.totalTransferPrice = (this.adult * this.transferPrice) + (this.child * this.transferPrice);
                this.totalPrice = `${this.totalAdultPrice + this.totalChildPrice + this.totalTransferPrice}`;
            }
        }
    }
});
