Vue.component("publishFeedback", {
	data: function () {
		return {
			patientFeedbacks: [],
			text: '',
			isAnonymous: false,
			isForPublishing: false,
			feedbackError: false
		}
	},
	template: `
	<div>
	
		<div class="boundaryForScrollPublish">
			<div class="logoAndName">
					<div class="logo">        
						<img src="pictures/clinic.png"/>
					</div>
					<div class="webName">
						<h3></h3>
					</div>  
				</div>
	 
				<div class="main">     
					<ul class="menu-contents">
					<li  class="active"><a href="#/">Utisci pacijenata</a></li>
					</ul>
				</div>
 
				<div class="dropdown">
					<button class="dropbtn">
						<img id="menuIcon" src="pictures/menuIcon.png" />
						<img id="userIcon" src="pictures/user.png" />
					</button>
				<div class="dropdown-content">
					<a >Registruj se</a>
					<a >Prijavi se</a>
				</div>
			</div>
		</div>
	 
	<div class="formForPublishingFeedback">
                 <div class="form-title">
                     <h1>Ostavite utisak</h1>
                          <br><br>
						<input type="text" id="feedbackID" v-model="text" placeholder="Ostavite Vas utisak..." >  
						<label v-if="feedbackError" style="color:red; font-size: 18px; margin-left: 16%">Morati popuniti polje kako biste ostavili utisak!</label><br><br>
						
						<input type="checkbox" id="isAnonymous" name="isAnonymous" value="isAnonymous" v-model = "isAnonymous">
						<label for="vehicle1"> Anonimno</label><br>
						<input type="checkbox" id="isForPublishing" name="isForPublishing" value="isForPublishing" v-model = "isForPublishing">
						<label for="vehicle2">Dozvoli objavljivanje</label><br>	
			
                         <div class="post-feedback-btn">
                             <button type="button" @click="postFeedback">Posalji</button>
                         </div>



                     </form>
                 </div>
             </div>

	 <div class="verticalLinePublishFeedback"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
		    <div><li><a href="#/patientsFeedbacks">Svi utisci</a></li></div><br/>
		    <div><li><a href="#/">Objavljeni utisci</a></li></div><br/>
			<div><li class="active" ><a href="#/publishFeedback">Ostavite utisak</a></li></div><br/>
	     </ul>
	 </div>
	 
		 


	 <div class="titleForPublishedFeedbackPreview">
		 <h1>Utisci pacijenata</h1>
	 </div> 
		 
	

	      
		  
	</div>
        
	`
	,
	methods: {
		postFeedback: function () {
			this.feedbackError = false;
			var empty = false;


			if (this.text.length === 0) {
				empty = true;
				this.feedbackError = true;
			}

			if (empty === false) {
				if (confirm('Da li ste sigurni da zelite da se ostavite utisak?') == true) {
					axios.post('/api/patientFeedback', {
						text: this.text,
						isForPublishing: this.isForPublishing,
						isPublished: false,
						isAnonymous: this.isAnonymous,
						patientID: 1,
						patient: null,
						publishingDate: "0001-01-01T00:00:00"
					});
					toast('Utisak je uspesno ostavljen')
				}
				else {
					this.$router.push({ name: 'publishFeedback' })

				}
			}


		}

	},
	mounted() {

		axios.get('api/patientFeedback/getPublishedFeedbacks').then(response => {
			this.patientFeedbacks = response.data;
		});

	}

});