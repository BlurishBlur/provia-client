/* 
 * Provider server
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace IO.Swagger.Model
{
    /// <summary>
    /// A short description of the post.
    /// </summary>
    [DataContract]
    public partial class Post :  IEquatable<Post>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets Types
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypesEnum
        {
            
            /// <summary>
            /// Enum AdminWarning for "AdminWarning"
            /// </summary>
            [EnumMember(Value = "AdminWarning")]
            AdminWarning,
            
            /// <summary>
            /// Enum Request for "Request"
            /// </summary>
            [EnumMember(Value = "Request")]
            Request,
            
            /// <summary>
            /// Enum Offer for "Offer"
            /// </summary>
            [EnumMember(Value = "Offer")]
            Offer,
            
            /// <summary>
            /// Enum NotAvailabe for "NotAvailabe"
            /// </summary>
            [EnumMember(Value = "NotAvailabe")]
            NotAvailabe
        }

        /// <summary>
        /// Gets or Sets Types
        /// </summary>
        [DataMember(Name="types", EmitDefaultValue=false)]
        public TypesEnum? Types { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Post" /> class.
        /// </summary>
        /// <param name="Id">Id.</param>
        /// <param name="Owner">Owner.</param>
        /// <param name="CreationDate">CreationDate.</param>
        /// <param name="Description">Description.</param>
        /// <param name="Types">Types.</param>
        /// <param name="Title">Title.</param>
        public Post(int? Id = null, string Owner = null, DateTime? CreationDate = null, string Description = null, TypesEnum? Types = null, string Title = null)
        {
            this.Id = Id;
            this.Owner = Owner;
            this.CreationDate = CreationDate;
            this.Description = Description;
            this.Types = Types;
            this.Title = Title;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }
        /// <summary>
        /// Gets or Sets Owner
        /// </summary>
        [DataMember(Name="owner", EmitDefaultValue=false)]
        public string Owner { get; set; }
        /// <summary>
        /// Gets or Sets CreationDate
        /// </summary>
        [DataMember(Name="creationDate", EmitDefaultValue=false)]
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Post {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  CreationDate: ").Append(CreationDate).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Types: ").Append(Types).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as Post);
        }

        /// <summary>
        /// Returns true if Post instances are equal
        /// </summary>
        /// <param name="other">Instance of Post to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Post other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Owner == other.Owner ||
                    this.Owner != null &&
                    this.Owner.Equals(other.Owner)
                ) && 
                (
                    this.CreationDate == other.CreationDate ||
                    this.CreationDate != null &&
                    this.CreationDate.Equals(other.CreationDate)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.Types == other.Types ||
                    this.Types != null &&
                    this.Types.Equals(other.Types)
                ) && 
                (
                    this.Title == other.Title ||
                    this.Title != null &&
                    this.Title.Equals(other.Title)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.Owner != null)
                    hash = hash * 59 + this.Owner.GetHashCode();
                if (this.CreationDate != null)
                    hash = hash * 59 + this.CreationDate.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.Types != null)
                    hash = hash * 59 + this.Types.GetHashCode();
                if (this.Title != null)
                    hash = hash * 59 + this.Title.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
