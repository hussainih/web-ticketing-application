using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Ticketing.Entity.TicketModel;

//Exmplanation
//    The proposal content class holds information about the HTML content of proposal thats supposed
//    to be submitted to

namespace Ticketing.TicketModel
{
    public class ProposalContent
    {
        public ProposalContent()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecId { get; set; }

        [AllowHtml]
        public string Content { get; set; }
        
        //Navigations
        
       


    }
}