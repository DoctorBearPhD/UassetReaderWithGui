using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UassetLib;
using UassetReaderWithGui.Model;
using UassetReaderWithGui.ViewModel.Controls;

namespace UassetReaderWithGui.Design
{
    public class DesignDataService : IDataService
    {
        public void SetArg(string arg) { }

        public void GetData(Action<ObservableCollection<DataItem>, Exception> callback)
        {
            // Use this to create design time data

            var items = new ObservableCollection<DataItem> {
                new DataItem("Design-time Item 1"),
                new DataItem("Design-time Item 2"),
                new DataItem("Design-time Item 3"),
                new DataItem("Design-time Item 4"),
                new DataItem("Design-time Item 5")
            };

            callback(items, null);
        }

        public void GetTreeViewData(Action<ObservableCollection<TreeViewItemViewModel>, Exception> callback)
        {
            // Use this to create design time data

            var items = new ObservableCollection<TreeViewItemViewModel> {
                new TreeViewItemViewModel("Design-time Item 1"),
                new TreeViewItemViewModel("Design-time Item 2"),
                new TreeViewItemViewModel("Design-time Item 3")
                {
                    Items = new ObservableCollection<TreeViewItemViewModel>
                    {
                        new TreeViewItemViewModel("Design-time Sub-item 1"),
                        new TreeViewItemViewModel("Design-time Sub-item 2"),
                        new TreeViewItemViewModel("Design-time Sub-item 3")
                    }
                },
                new TreeViewItemViewModel("Design-time Item 4"),
                new TreeViewItemViewModel("Design-time Item 5")
            };

            callback(items, null);
        }

        public void GetStructPropertyData(Action<StructProperty, Exception> callback)
        {
            var structProp = new StructProperty();
            var value = new Dictionary<string, object>
            {
                ["Attribute"] = new ArrayProperty()
                {
                    PropertyType = typeof(StructProperty).Name,
                    Items = new ObservableCollection<dynamic> { new StructProperty(), new StructProperty(), new StructProperty() }
                }
            };

            structProp.Value = value;

            callback(structProp, null);
        }

        public void GetStringListData(Action<ObservableCollection<StringProperty>, Exception> callback)
        {
            // var bigString = "..."
            #region String of Strings
            var bigString = @"/Game/Chara/CMN/DataAsset/DA_CMN_StunAttachment
/Game/Chara/CMN/Skeleton/AnimBlueprint/KAB_CMN
/Game/Chara/KEN/DA_KEN_Setup
/Game/Chara/KEN/DataAsset/DA_KEN_AnimSeqWithIdContainer
/Game/Chara/KEN/DataAsset/DA_KEN_PSListContainer
/Game/Chara/KEN/DataAsset/DA_KEN_SoundPath
/Game/Chara/KEN/DataAsset/DA_KEN_Subtitle
/Game/Chara/KEN/DataAsset/DA_KEN_TrailList
/Game/Chara/KEN/SkelMesh/Common/Mesh/KEN_SKL
/Game/Chara/RYU/BlendSpace/BS_RYU_AIM_EYE
/Game/Chara/RYU/BlendSpace/BS_RYU_AIM_HEAD
/Game/Sound/BGM/TransitionRules/DA_CMN_BGMTransitionRule
/Script/CoreUObject
/Script/Engine
/Script/KiwiChara
/Script/KiwiGame
/Script/KiwiVfx
AimEye
AimHead
AimOffsetBlendSpace
AnimBlueprint
AnimSequenceList
ArrayProperty
BGMs
BoneSkeltalMesh
BS_RYU_AIM_EYE
BS_RYU_AIM_HEAD
ByteProperty
Class
costume_offset
CreateVfxID
CueSheet
DA_CMN_BGMTransitionRule
DA_CMN_StunAttachment
DA_KEN_AnimSeqWithIdContainer
DA_KEN_PSListContainer
DA_KEN_Setup
DA_KEN_SoundPath
DA_KEN_Subtitle
DA_KEN_TrailList
EKWBGM
EKWBGM::BattleMain
id
IntProperty
KAB_CMN
KEN_SKL
KWAnimSequenceWithIdListContainerDataAsset
KWBattleBGMTransitionDataAsset
KWBattleCharaSetupDataAsset
KWCharaSoundEntryDataAsset
KWParticleSystemListContainerDataAsset
KWStunAttachmentDataAsset
KWSubtitleDataAsset
KWTrailDataListAsset
mesh_id
MirrorType
node_local_offset
node_local_rotation
None
ObjectProperty
Package
ParticleSystemList
Rotator
SetNodeID
SettingMirrorType
SettingMirrorType::NONE
SettingVFxKind
SettingVFxKind::FOLLOW_NODE_ROT
SkeletalMesh
Slot
SoundResource
StringAssetReference
StructProperty
StunAttachment
SubtitleData
TrailDataListAsset
TransitionSetting
Vector
VfxKind
VfxList
VTriggerVFxLists";
            #endregion

            var strings = bigString
                .Split(new [] { Environment.NewLine }, StringSplitOptions.None )
                .Select(item => new StringProperty(item));

            callback(new ObservableCollection<StringProperty>(strings), null);
        }

        public void GetUassetFile(Action<UassetFile, Exception> callback)
        {
            var uf = new UassetFile();

            GetStringListData( (list, ex) => { uf.StringList = list; } );
            uf.StringListCount = uf.StringList.Count;
            uf.PreContentSize = 0xBA9;

            uf.PtrNoneString =      0x025;
            uf.DeclarePtr =         0x85F;
            uf.UnknownList1Ptr =    0xAFF;
            uf.ImportsListPtr =     0xB43;
            uf.UkDependsPtr =       0xB73;
            uf.UnknownPtr =         0xBA5;
            uf.PtrFooter =          0x1093;

            uf.Declaration = new DeclarationBlock { Items = new List<DeclarationItem> { new DeclarationItem { Id = 1, Namespace = "Namespace?", Name = "Name!", Depends = 10, @Type = "Type?!", Item6 = 99, Items = new int[] { 1,2,3,4,5,6,7 } } } };
            uf.UnknownList1 = new UnknownList1Block { Items = new List<UnknownList1Item> { new UnknownList1Item { Id = 3, Name = "Name Example", Namespace = "Namespace Example", Size = 9999, PtrToContent = 0x6969 } } };

            callback(uf, null);
        }
    }
}