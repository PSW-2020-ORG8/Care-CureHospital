Vue.component("prescriptionForAppointment", {
	data: function () {
		return {
			prescriptionForAppointment: null,
			userToken: null,
			loggedUserId: 0
		}
	},
	template: `
	<div>
	
	<div class="boundaryForScrollPrescriptions">
	     <div class="logoAndName">
	         <div class="logo">        
	             <img src="images/hospital.png"/>
	         </div>
	         <div class="webName">
	             <h3></h3>
	         </div>  
	     </div>
	 
	     <div class="main">     
	         <ul class="menu-contents">
				<li><a href="#/patientAppointments">Nazad na preglede</a></li>
	         </ul>
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
	
	<div class="prescription-for-appointment">	
		<div class="report-img">
			<img src="./images/medical-prescription.png" height="170" width="170" style="margin-left: 12%; margin-top: 12%;">
		</div>

		<h1 class="title">Recept sa pregleda</h1></br>
		<h2 style="margin-left:330px">Doktor: {{this.prescriptionForAppointment.doctor}}</h2></br>	
		<h2 style="margin-left:330px">Datum: {{this.prescriptionForAppointment.publishingDate}}</h2></br>
		<div class="left-content">
			<h2 style="margin-right:300px">Komentar:</h2></br>
			<div style="overflow-y:scroll;height:150px;width:350px;border:1px solid;padding: 5px 5px 10px 5px">
				{{this.prescriptionForAppointment.comment}}
			</div>
		</div>
		<div class="right-content">
			<h2>Lekovi:</h2></br>
			<div style="overflow-y:scroll;height:150px;width:260px;border:1px solid;padding: 5px 5px 10px 5px">
				<div v-for="medicament in this.prescriptionForAppointment.medicaments">
					{{medicament.name}}
				</div>
			</div>
		</div>
	</div>     
	</div>	  
	</div>
        
	`
	,
	methods: {
		
		logOut: function () {
			localStorage.removeItem("validToken");
		}
	},
	computed: {

	},
	mounted() {
		this.userToken = localStorage.getItem('validToken');
		if (this.userToken !== null) {
			var base64Url = this.userToken.split('.')[1];
			var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
			var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
				return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
			}).join(''));

			this.decodedToken = JSON.parse(jsonPayload);
			this.loggedUserId = parseInt(this.decodedToken.unique_name);
		}

		if (this.$route.params.prescription !== null) {
			this.prescriptionForAppointment = this.$route.params.prescription;
		}

	}
});