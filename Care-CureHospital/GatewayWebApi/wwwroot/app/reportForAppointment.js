Vue.component("reportForAppointment", {
	data: function () {
		return {
			reportForAppointment: null,
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
			<img src="./images/medical-report.png" height="170" width="170" style="margin-left: 12%; margin-top: 12%;">
		</div>		
			<h1 class="title">Izveštaj sa pregleda</h1></br>
			<h2 style="margin-left:330px">Doktor: {{this.reportForAppointment.doctor}}</h2></br>
			<h2 style="margin-left:330px">Datum: {{this.reportForAppointment.publishingDate}}</h2></br>
			<h2 style="margin-left:330px">Soba: {{this.reportForAppointment.room}}</h2></br>			
			<h2 style="margin-right:300px">Komentar:</h2></br>
			<div style="overflow-y:scroll;height:150px;width:690px;border:1px solid;padding: 5px 5px 10px 5px">
				{{this.reportForAppointment.comment}}
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

		if (this.$route.params.report !== null) {
			this.reportForAppointment = this.$route.params.report;
		}

	}
});