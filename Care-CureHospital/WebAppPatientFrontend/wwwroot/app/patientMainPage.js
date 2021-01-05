Vue.component("patientMainPage", {
    data: function () {
        return {
            slideIndex: 1,
            advertisements: [],
            firstAddPharmacyName: '',
            firstAddPercent: 0,
            firstAddPeriod: '',
            firstAddManufacturer: '',
            secondAddPharmacyName: '',
            secondAddPercent: 0,
            secondAddPeriod: '',
            secondAddManufacturer: '',
            thirdAddPharmacyName: '',
            thirdAddPercent: 0,
            thirdAddPeriod: '',
            thirdAddManufacturer: '',
        }
    },
    template: `
    <div>
    
        <div class="logo-and-name-appointment-scheduling-by-recommendation">
            <div class="logo-appointment-scheduling-by-recommendation">        
                <img src="images/hospital.png"/>
            </div>
            <div class="web-name-appointment-scheduling-by-recommendation">
                <h3></h3>
            </div>  
        </div>

        <div class="main-appointment-scheduling-by-recommendation">     
            <ul class="menu-contents">
                <li><a href="#/patientAppointments" id="appointments-link">Pregledi</a></li>
                <li><a href="#/" id="feedbacks-link">Utisci</a></li>
                <li class="active"><a href="#/patientMainPage">Početna</a></li>
                <li><a href="#/medicalRecordReview">Moj karton</a></li>
                <li><a href="#/patientDocumentsSimpleSearch">Dokumenti</a></li>
            </ul>
        </div>

        <div class="title-patient-main-page">
            <h1>Vaše zdravlje je u našim rukama!</h1>
        </div>

        <div class="dropdown">
            <button class="dropbtn">
                <img id="menuIcon" src="images/menuIcon.png" />
                <img id="userIcon" src="images/user.png" />
            </button>
            <div class="dropdown-content">
                <a href="#/userLogin" @click="logOut()">Odjavi se</a>
            </div>
        </div>

        <div class="slideshow-container">
     
        <div class="mySlides fade">
            <img src="./images/first.jpg" style="width:100%; height:480px; margin-bottom:-0.4%">
            <div class="text_pharmacy_name">
                <h1 style="color:black;float:left; font-size: 24px;">Apoteka: {{this.firstAddPharmacyName}}  </h1><br>
            </div>
            <div class="text_discount">
                <h1 style="color:black;float:left; font-size: 24px; ">Popust: {{this.firstAddPercent}}%  </h1><br>
            </div>
            <div class="text_period">
                <h1 style="color:black;float:left; font-size: 24px; ">Period: {{this.firstAddPeriod}}  </h1><br>
            </div>
            <div class="text_product">
                <h1 style="color:black;float:left; font-size: 24px; ">Proizvod: {{this.firstAddManufacturer}} </h1><br>
            </div>
        </div>

        <div class="mySlides fade">
            <img src="./images/second.jpg" style="width:100%; height:480px; margin-bottom:-0.4%">
            <div class="text_pharmacy_name">
                <h1 style="color:black;float:left; font-size: 24px;">Apoteka: {{this.secondAddPharmacyName}}  </h1><br>
            </div>
            <div class="text_discount">
                <h1 style="color:black;float:left; font-size: 24px; ">Popust: {{this.secondAddPercent}}%  </h1><br>
            </div>
            <div class="text_period">
                <h1 style="color:black;float:left; font-size: 24px; ">Period: {{this.secondAddPeriod}}  </h1><br>
            </div>
            <div class="text_product">
                <h1 style="color:black;float:left; font-size: 24px; ">Proizvod: {{this.secondAddManufacturer}} </h1><br>
            </div>
        </div>

        <div class="mySlides fade">
            <img src="./images/third.jpg" style="width:100%; height:480px; margin-bottom:-0.4%">
            <div class="text_pharmacy_name">
                <h1 style="color:black;float:left; font-size: 24px;">Apoteka: {{this.thirdAddPharmacyName}}  </h1><br>
            </div>
            <div class="text_discount">
                <h1 style="color:black;float:left; font-size: 24px; ">Popust: {{this.thirdAddPercent}}%  </h1><br>
            </div>
            <div class="text_period">
                <h1 style="color:black;float:left; font-size: 24px; ">Period: {{this.thirdAddPeriod}}  </h1><br>
            </div>
            <div class="text_product">
                <h1 style="color:black;float:left; font-size: 24px; ">Proizvod: {{this.thirdAddManufacturer}} </h1><br>
            </div>
        </div>

        <a class="prev" @click="plusSlides(-1)">&#10094;</a>
        <a class="next" @click="plusSlides(1)">&#10095;</a>
        
        </div>

        <br>

        <div style="text-align:center; margin-left:-2%;">
            <span class="dot" @click="currentSlide(1)"></span>
            <span class="dot" @click="currentSlide(2)"></span>
            <span class="dot" @click="currentSlide(3)"></span>
        </div>
	 	  
	</div>
        
    `
    ,
    components: {

    }
    ,
    computed: {

    },
    methods: {
        showSlides: function (n) {
            var i;
            var slides = document.getElementsByClassName("mySlides");
            var dots = document.getElementsByClassName("dot");
            if (n > slides.length) { this.slideIndex = 1 }
            if (n < 1) { this.slideIndex = slides.length }
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" dot-active", "");
            }
            slides[this.slideIndex - 1].style.display = "block";
            dots[this.slideIndex - 1].className += " dot-active";
        },
        plusSlides: function (n) {
            this.showSlides(this.slideIndex += n);
        },
        currentSlide: function (n) {
            this.showSlides(this.slideIndex = n);
        },
        logOut: function () {
            localStorage.removeItem("validToken");
        }

    },
    mounted() {
        this.showSlides(this.slideIndex);
        axios.get('gateway/advertisement', {
            headers: {
                'Authorization': 'Bearer ' + this.userToken
            }
        }).then(response => {
            this.advertisements = response.data
            this.firstAddPharmacyName = this.advertisements[0].pharmacyName
            this.firstAddPercent = this.advertisements[0].percent
            this.firstAddPeriod = this.advertisements[0].period
            this.firstAddManufacturer = this.advertisements[0].manufacturer
            this.secondAddPharmacyName = this.advertisements[1].pharmacyName
            this.secondAddPercent = this.advertisements[1].percent
            this.secondAddPeriod = this.advertisements[1].period
            this.secondAddManufacturer = this.advertisements[1].manufacturer
            this.thirdAddPharmacyName = this.advertisements[2].pharmacyName
            this.thirdAddPercent = this.advertisements[2].percent
            this.thirdAddPeriod = this.advertisements[2].period
            this.thirdAddManufacturer = this.advertisements[2].manufacturer

        }).catch(error => {
            if (error.response.status === 401 || error.response.status === 403) {
                toast('Nemate pravo pristupa stranici!')
                this.$router.push({ name: 'userLogin' })
            }
        });
    }
});