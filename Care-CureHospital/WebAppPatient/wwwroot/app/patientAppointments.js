Vue.component("patientAppointments", {
	data: function () {
		return {
			filterAppointments: 'Svi pregledi',
			scheduledAppointments: [],
			previousAppointments: []
		}
	},
	template: `
	<div>	
	<div class="boundaryForScrollAppointments">
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
	            <li  class="active"><a href="#/medicalRecordReview">Moj nalog</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="images/menuIcon.png" />
	        	<img id="userIcon" src="images/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a href="#/patientRegistration">Registruj se</a>
	            <a >Prijavi se</a>
		    </div>
	    </div>
	 </div>
	 
	<div class="filterAppointments">
            <div class="form-title-appointments">
                <h1>Filtriraj preglede:</h1>
                <select v-model="filterAppointments">
                <option value="Svi pregledi" selected>Svi pregledi</option>
				<option value="Zakazani pregledi">Zakazani pregledi</option>
				<option value="Pregledi na kojima sam bio">Pregledi na kojima sam bio</option>
                </select>
		    </div>
     </div>

	 <div class="verticalLine"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
			<div><li><a href="#/medicalRecordReview">Medicinski karton</a></li></div><br/>
		    <div><li class="active"><a href="#/patientAppointments">Moji pregledi</a></li></div><br/>
	     </ul>
	 </div> 	

	<div class="listOfAppointments">		 
		<div v-for="appointment in this.previousAppointments">	
			<div class="wrapper-appointments">
				<div class="appointments-img">
					<img src="./images/previousAppointment.png" height="150" width="150" style="margin-left: 20%; margin-top: 14%;">
				</div>
				<div class="appointments-info">
					<div class="appointments-text">
						<h1>dr {{appointment.doctorFullName}}</h1> 
						<h3>- {{appointment.doctorSpecialization}}</h3>
						<h3 style="margin-top:8px"><i>Ordinacija:</i> {{appointment.room}}</h3>
						<h3 style="margin-top:8px"><i>Vreme:</i> {{appointment.period}}</h3>
						<p>{{appointment.date}}</p>
						<div class="cancelAppointment-btn">
							<button type="button" @click="fillSurvey(appointment.medicalExaminationId)">Popuni anketu</button>
						</div>	
						<!--<div class="appointmentsParagraph1">
							<p>Popunili ste anketu</p>
						</div>-->
					</div>
				</div>		
			</div>
		</div>	
		<div v-for="appointment in this.scheduledAppointments">	
			<div class="wrapper-appointments">
				<div class="appointments-img">
					<img src="./images/scheduledAppointment.png" height="150" width="150" style="margin-left: 20%; margin-top: 14%;">
				</div>
				<div class="appointments-info">
					<div class="appointments-text">
						<h1>dr {{appointment.doctorFullName}}</h1> 
						<h3>- {{appointment.doctorSpecialization}}</h3>
						<h3 style="margin-top:8px"><i>Ordinacija:</i> {{appointment.room}}</h3>
						<h3 style="margin-top:8px"><i>Vreme:</i> {{appointment.period}}</h3>
						<p>{{appointment.date}}</p>
						

					</div>
				</div>		
			</div>
		</div>	
	</div>

	</div>
        
	`
	,
	methods: {
		

		fillSurvey: function (medicalExaminationForSurvey) {
			this.$router.push({ name: 'surveyAfterExamination', params: { medicalExaminationId: medicalExaminationForSurvey } })
		}
	},
	computed: {
		
	},
	mounted() {

		axios.get('api/appointment/getScheduledAppointmetsByPatient/' + 1).then(response => {
			this.scheduledAppointments = response.data;
			axios.get('api/appointment/getPreviousAppointmetsByPatient/' + 1).then(response => {
				this.previousAppointments = response.data;
			});		
		});
	}

});