﻿#region license
/* Copyright (c) 2016, DMagic
All rights reserved.

ToggleSpriteHandler - Script to handle switching sprites on button press

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.
2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

The views and conclusions contained in the software and documentation are those
of the authors and should not be interpreted as representing official policies,
either expressed or implied, of the FreeBSD Project.
*/
#endregion

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SEPScience.Unity
{
	[RequireComponent(typeof(Image))]
	public class ToggleSpriteHandler : MonoBehaviour
	{
		[SerializeField]
		private Sprite OnSprite = null;
		[SerializeField]
		private Sprite OffSprite = null;
		[SerializeField]
		private Toggle ParentToggle = null;

		private Image image;

		private void Awake()
		{
			if (ParentToggle == null || OnSprite == null || OffSprite == null)
				return;

			ParentToggle.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<bool>(onToggle));

			image = GetComponent<Image>();
		}

		public void onToggle(bool isOn)
		{
			if (image == null || OnSprite == null || OffSprite == null)
				return;

			image.sprite = isOn ? OnSprite : OffSprite;
		}
	}
}
